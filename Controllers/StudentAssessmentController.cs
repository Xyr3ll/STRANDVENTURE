using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Security;
using STRANDVENTURE.Services;
using System.Linq; // added for LINQ extensions

namespace STRANDVENTURE.Controllers;

public class StudentAssessmentController : StudentPortalControllerBase
{
    private readonly IAssessmentProgressService _progressService;
    private const string SessionAchievementKey = "ShownAchievements";
    public StudentAssessmentController(ApplicationDbContext db, IStudentService studentService, IPasswordHasher passwordHasher, IAssessmentProgressService progressService)
        : base(db, studentService, passwordHasher) { _progressService = progressService; }

    private HashSet<string> GetShownAchievementCodes()
    {
        var raw = HttpContext.Session.GetString(SessionAchievementKey);
        if (string.IsNullOrWhiteSpace(raw)) return new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        return new HashSet<string>(raw.Split('|', StringSplitOptions.RemoveEmptyEntries), StringComparer.OrdinalIgnoreCase);
    }

    private void MarkAchievementShown(string code)
    {
        var set = GetShownAchievementCodes();
        if (set.Add(code))
            HttpContext.Session.SetString(SessionAchievementKey, string.Join('|', set));
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect;

        var openAttempt = await Db.StudentAssessmentAttempts
            .FirstOrDefaultAsync(a => a.StudentId == student.Id && !a.IsCompleted, ct);

        var attemptCount = await Db.StudentAssessmentAttempts.CountAsync(a => a.StudentId == student.Id, ct);

        var vm = new StudentAssessmentViewModel
        {
            Student = student,
            ExistingAttempts = attemptCount,
            CanStartNewAttempt = openAttempt == null,
            ActiveAttemptId = openAttempt?.Id
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Start(CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect;

        var openAttempt = await Db.StudentAssessmentAttempts
            .AnyAsync(a => a.StudentId == student.Id && !a.IsCompleted, ct);
        if (openAttempt)
        {
            TempData["Error"] = "You already have an active assessment attempt.";
            return RedirectToAction(nameof(Index));
        }

        var nextNumber = await Db.StudentAssessmentAttempts
            .Where(a => a.StudentId == student.Id)
            .MaxAsync(a => (int?)a.AttemptNumber, ct) ?? 0;

        var attempt = new StudentAssessmentAttempt
        {
            StudentId = student.Id,
            AttemptNumber = nextNumber + 1
        };
        Db.StudentAssessmentAttempts.Add(attempt);
        await Db.SaveChangesAsync(ct);
        return RedirectToAction(nameof(Take), new { attemptId = attempt.Id });
    }

    // Countdown + question view
    public async Task<IActionResult> Take(Guid attemptId, CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect;

        var attempt = await Db.StudentAssessmentAttempts.FirstOrDefaultAsync(a => a.Id == attemptId && a.StudentId == student.Id, ct);
        if (attempt == null) return NotFound();
        if (attempt.IsCompleted) return RedirectToAction(nameof(Index));

        var answeredIds = await Db.StudentAssessmentAnswers
            .Where(a => a.AttemptId == attempt.Id)
            .Select(a => a.QuestionId)
            .ToListAsync(ct);

        var nextQuestion = await Db.Questions
            .Where(q => q.IsActive)
            .OrderBy(q => q.QuestionOrder)
            .FirstOrDefaultAsync(q => !answeredIds.Contains(q.Id), ct);

        StudentAssessmentTakeViewModel.QuestionDto? questionDto = null;
        if (nextQuestion != null)
        {
            var options = await Db.QuestionOptions
                .Where(o => o.QuestionId == nextQuestion.Id)
                .OrderBy(o => o.OptionLetter)
                .Select(o => new StudentAssessmentTakeViewModel.OptionDto { Id = o.Id, Letter = o.OptionLetter, Text = o.OptionText })
                .ToListAsync(ct);
            questionDto = new StudentAssessmentTakeViewModel.QuestionDto
            {
                Id = nextQuestion.Id,
                Text = nextQuestion.QuestionText,
                Options = options
            };
        }

        var totalQuestions = await Db.Questions.CountAsync(q => q.IsActive, ct);
        var answeredCount = answeredIds.Count;

        // Single translated query to get raw weight sums + strand names + colors
        var rawWithNames = await Db.StudentAssessmentAnswers
            .Where(a => a.AttemptId == attempt.Id)
            .Join(Db.QuestionOptionStrandWeights,
                a => a.QuestionOptionId,
                w => w.QuestionOptionId,
                (a, w) => new { w.StrandId, w.Weight })
            .GroupBy(x => x.StrandId)
            .Select(g => new { StrandId = g.Key, Raw = g.Sum(x => x.Weight) })
            .Join(Db.Strands,
                g => g.StrandId,
                st => st.Id,
                (g, st) => new { st.Id, st.Name, st.Color, g.Raw })
            .ToListAsync(ct);

        var totalRaw = rawWithNames.Sum(x => x.Raw);
        var strandScores = rawWithNames
            .Select(x => new StudentAssessmentTakeViewModel.StrandScoreDto
            {
                StrandId = x.Id,
                StrandName = x.Name,
                ScorePercent = totalRaw > 0 ? decimal.Round((x.Raw / totalRaw) * 100m, 2) : 0m,
                Color = string.IsNullOrWhiteSpace(x.Color) ? "#1e6bff" : x.Color // changed fallback
            })
            .OrderByDescending(s => s.ScorePercent)
            .ToList();

        var vm = new StudentAssessmentTakeViewModel
        {
            AttemptId = attempt.Id,
            TotalQuestions = totalQuestions,
            AnsweredQuestions = answeredCount,
            CurrentQuestion = questionDto,
            StrandScores = strandScores
        };
        return View("Take", vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Answer(Guid attemptId, Guid questionId, Guid optionId, CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect;

        var attempt = await Db.StudentAssessmentAttempts.FirstOrDefaultAsync(a => a.Id == attemptId && a.StudentId == student.Id, ct);
        if (attempt == null) return NotFound();
        if (attempt.IsCompleted) return RedirectToAction(nameof(Take), new { attemptId });

        // Prevent duplicate answers
        var exists = await Db.StudentAssessmentAnswers.AnyAsync(a => a.AttemptId == attemptId && a.QuestionId == questionId, ct);
        if (!exists)
        {
            Db.StudentAssessmentAnswers.Add(new StudentAssessmentAnswer
            {
                AttemptId = attemptId,
                QuestionId = questionId,
                QuestionOptionId = optionId
            });
            await Db.SaveChangesAsync(ct);
        }

        // Check completion
        var totalQuestions = await Db.Questions.CountAsync(q => q.IsActive, ct);
        var answered = await Db.StudentAssessmentAnswers.CountAsync(a => a.AttemptId == attemptId, ct);
        if (answered >= totalQuestions)
        {
            await FinalizeAttemptAsync(attempt, attemptId, ct);
            return RedirectToAction("Index", "StudentResults");
        }
        return RedirectToAction(nameof(Take), new { attemptId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AnswerAjax(Guid attemptId, Guid questionId, Guid optionId, CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return Json(new { success = false, redirect = true, url = Url.Action("Index", "StudentAssessment") });

        var attempt = await Db.StudentAssessmentAttempts.FirstOrDefaultAsync(a => a.Id == attemptId && a.StudentId == student.Id, ct);
        if (attempt == null) return Json(new { success = false, message = "Attempt not found" });
        if (attempt.IsCompleted) return Json(new { success = true, completed = true, nextUrl = Url.Action("Index", "StudentResults") });

        AssessmentProgressService.AnswerResult? result = null;
        if (!await Db.StudentAssessmentAnswers.AnyAsync(a => a.AttemptId == attemptId && a.QuestionId == questionId, ct))
        {
            try
            {
                result = await _progressService.RecordAnswerAsync(attemptId, questionId, optionId, ct);
                // NOTE: Do not mark session as shown yet; we need to decide after computing shouldShowHalfway
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        var totalQuestions = await Db.Questions.CountAsync(q => q.IsActive, ct);
        var answered = await Db.StudentAssessmentAnswers.CountAsync(a => a.AttemptId == attemptId, ct);
        var completed = answered >= totalQuestions;
        if (completed)
        {
            await FinalizeAttemptAsync(attempt, attemptId, ct);
        }

        // Recalculate strand scores (normalized) including color + description + id
        var rawWithNames = await Db.StudentAssessmentAnswers
            .Where(a => a.AttemptId == attemptId)
            .Join(Db.QuestionOptionStrandWeights,
                a => a.QuestionOptionId,
                w => w.QuestionOptionId,
                (a, w) => new { w.StrandId, w.Weight })
            .GroupBy(x => x.StrandId)
            .Select(g => new { StrandId = g.Key, Raw = g.Sum(x => x.Weight) })
            .Join(Db.Strands, g => g.StrandId, st => st.Id, (g, st) => new { st.Id, st.Name, st.Color, st.Description, g.Raw })
            .ToListAsync(ct);
        var totalRaw = rawWithNames.Sum(x => x.Raw);
        var strandScores = rawWithNames
            .Select(x => new { id = x.Id, name = x.Name, percent = totalRaw > 0 ? Math.Round((double)(x.Raw / totalRaw * 100m), 2) : 0d, color = string.IsNullOrWhiteSpace(x.Color)?"#1e6bff":x.Color, description = x.Description })
            .OrderByDescending(x => x.percent)
            .ToList();

        // Pick top strand + live quiz (if any) for scaffolding quiz entry
        string? topQuizUrl = null;
        var topStrandId = strandScores.FirstOrDefault()?.id;
        if (completed && topStrandId.HasValue)
        {
            var liveQuiz = await Db.StrandQuizzes.FirstOrDefaultAsync(q => q.StrandId == topStrandId && q.IsLive, ct);
            if (liveQuiz != null)
            {
                topQuizUrl = Url.Action("StartFromAssessment", "StudentStrandQuiz", new { strandId = topStrandId });
            }
        }

        // Use the result from the service to determine if halfway achievement was just awarded
        var shownCodes = GetShownAchievementCodes();
        bool shouldShowHalfway = result != null && result.HalfwayAwarded && result.AchievementAwarded != null 
            && !shownCodes.Contains(result.AchievementAwarded.Code);

        // Now that we've decided to show, mark it so refresh won't re-show
        if (shouldShowHalfway && result!.AchievementAwarded != null)
        {
            MarkAchievementShown(result.AchievementAwarded.Code);
        }

        return Json(new
        {
            success = true,
            completed,
            nextUrl = completed ? Url.Action("Index", "StudentResults") : Url.Action("Take", new { attemptId }),
            strandScores,
            topQuizUrl, // new field
            halfway = shouldShowHalfway ? new { code = result!.AchievementAwarded!.Code, name = result.AchievementAwarded.Name, description = result.AchievementAwarded.Description, icon = result.AchievementAwarded.Icon } : null
        });
    }

    private async Task FinalizeAttemptAsync(StudentAssessmentAttempt attempt, Guid attemptId, CancellationToken ct)
    {
        attempt.IsCompleted = true;
        attempt.CompletedAt = DateTime.UtcNow;
        var strandAggRaw = await Db.StudentAssessmentAnswers
            .Where(a => a.AttemptId == attemptId)
            .Join(Db.QuestionOptionStrandWeights,
                a => a.QuestionOptionId,
                w => w.QuestionOptionId,
                (a, w) => new { w.StrandId, w.Weight })
            .GroupBy(x => x.StrandId)
            .Select(g => new { StrandId = g.Key, Raw = g.Sum(x => x.Weight) })
            .ToListAsync(ct);
        var totalRaw = strandAggRaw.Sum(s => s.Raw);
        foreach (var s in strandAggRaw)
        {
            var percent = totalRaw > 0 ? (s.Raw / totalRaw) * 100m : 0m;
            var existsScore = await Db.StudentAssessmentStrandScores.AnyAsync(sc => sc.AttemptId == attemptId && sc.StrandId == s.StrandId, ct);
            if (!existsScore)
            {
                Db.StudentAssessmentStrandScores.Add(new StudentAssessmentStrandScore
                {
                    AttemptId = attemptId,
                    StrandId = s.StrandId,
                    ScorePercent = decimal.Round(percent, 2)
                });
            }
        }
        if (strandAggRaw.Any())
        {
            attempt.TotalScorePercent = decimal.Round(strandAggRaw.Max(s => totalRaw > 0 ? (s.Raw / totalRaw) * 100m : 0m), 2);
        }

        // HONOR FIRST ASSESSMENT: only create StudentAssessmentResult if student has none yet
        var hasResult = await Db.StudentAssessmentResults.AnyAsync(r => r.StudentId == attempt.StudentId, ct);
        if (!hasResult && strandAggRaw.Any())
        {
            var top = strandAggRaw.OrderByDescending(s => s.Raw).First();
            // Get the recommended strand name for feedback
            var strand = await Db.Strands.FirstOrDefaultAsync(s => s.Id == top.StrandId, ct);
            string feedback = StrandResultDescriptions.GetRandomDescription(strand?.Name ?? "Strand");
            Db.StudentAssessmentResults.Add(new StudentAssessmentResult
            {
                StudentId = attempt.StudentId,
                AttemptId = attempt.Id,
                RecommendedStrandId = top.StrandId,
                FeedbackDescription = feedback
            });
        }

        // NEW: clear teacher notifications when student finishes assessment
        var notify = await Db.StudentNotifyAssessments.Where(n => n.StudentId == attempt.StudentId).ToListAsync(ct);
        if (notify.Count > 0)
            Db.StudentNotifyAssessments.RemoveRange(notify);

        await Db.SaveChangesAsync(ct);
    }
}
