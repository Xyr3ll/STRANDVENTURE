using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Security;
using STRANDVENTURE.Services;
using System.Text.Json;

namespace STRANDVENTURE.Controllers;

public class StudentStrandQuizController : StudentPortalControllerBase
{
    private const string SessionKeyPrefix = "SSQ_STATE_"; // + quizId
    private readonly IStudentStrandQuizResultService _quizResultService;

    // DTO for returning per-option per-strand raw weights to the client
    private sealed class StrandWeightDto
    {
        public string strand { get; set; } = string.Empty;
        public decimal weight { get; set; }
    }

    public StudentStrandQuizController(ApplicationDbContext db, IStudentService studentService, IPasswordHasher passwordHasher, IStudentStrandQuizResultService quizResultService)
        : base(db, studentService, passwordHasher) {
        _quizResultService = quizResultService;
    }

    // Student-facing: return honored attempt answers for the currently logged-in student
    [HttpGet]
    public async Task<IActionResult> MyAnswers(CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect!;

        if (student == null) return Unauthorized();

        // Find honored result (if any)
        var result = await Db.StudentAssessmentResults.AsNoTracking().FirstOrDefaultAsync(r => r.StudentId == student.Id, ct);
        if (result is null)
            return Ok(new { data = Array.Empty<object>() });

        var answers = await Db.StudentAssessmentAnswers
            .Where(a => a.AttemptId == result.AttemptId)
            .Include(a => a.Question)
            .Include(a => a.QuestionOption)
            .OrderBy(a => a.Question.QuestionOrder)
            .Select(a => new
            {
                questionId = a.QuestionId,
                question = a.Question.QuestionText,
                selectedOptionId = a.QuestionOptionId,
                selectedOption = a.QuestionOption.OptionText,
                selectedLetter = a.QuestionOption.OptionLetter,
                isCorrect = a.QuestionOption.IsCorrect
            })
            .ToListAsync(ct);

        var questionIds = answers.Select(x => x.questionId).Distinct().ToList();
        var correctOptions = await Db.QuestionOptions
            .Where(o => questionIds.Contains(o.QuestionId) && o.IsCorrect)
            .Select(o => new { o.QuestionId, correctOption = o.OptionText, correctLetter = o.OptionLetter })
            .ToListAsync(ct);

        var correctByQ = correctOptions.ToDictionary(x => x.QuestionId, x => new { x.correctOption, x.correctLetter });

        var selectedOptionIds = answers.Select(a => a.selectedOptionId).Where(id => id != Guid.Empty).Distinct().ToList();
        var optionWeights = await Db.QuestionOptionStrandWeights
            .Where(w => selectedOptionIds.Contains(w.QuestionOptionId))
            .GroupBy(w => w.QuestionOptionId)
            .Select(g => new { OptionId = g.Key, TotalWeight = g.Sum(x => x.Weight) })
            .ToListAsync(ct);
        var weightByOption = optionWeights.ToDictionary(x => x.OptionId, x => x.TotalWeight);

        var optionStrandRows = await Db.QuestionOptionStrandWeights
            .Where(w => selectedOptionIds.Contains(w.QuestionOptionId))
            .Include(w => w.Strand)
            .Select(w => new { w.QuestionOptionId, Strand = w.Strand.Name, w.Weight })
            .ToListAsync(ct);
        var strandWeightsByOption = optionStrandRows
            .GroupBy(x => x.QuestionOptionId)
            .ToDictionary(g => g.Key, g => g.Select(x => new StrandWeightDto { strand = x.Strand, weight = x.Weight }).ToList());

        var optionWeightsWithQuestion = await (
            from w in Db.QuestionOptionStrandWeights
            join o in Db.QuestionOptions on w.QuestionOptionId equals o.Id
            where questionIds.Contains(o.QuestionId)
            group w by new { o.QuestionId, w.QuestionOptionId } into g
            select new { QuestionId = g.Key.QuestionId, OptionId = g.Key.QuestionOptionId, TotalWeight = g.Sum(x => x.Weight) }
        ).ToListAsync(ct);

        var totalByQuestion = optionWeightsWithQuestion
            .GroupBy(x => x.QuestionId)
            .ToDictionary(g => g.Key, g => g.Sum(x => x.TotalWeight));

        var enriched = answers.Select(a => new
        {
            a.questionId,
            a.question,
            a.selectedOptionId,
            a.selectedOption,
            a.selectedLetter,
            a.isCorrect,
            correctOption = correctByQ.TryGetValue(a.questionId, out var c) ? c.correctOption : string.Empty,
            correctLetter = correctByQ.TryGetValue(a.questionId, out var c2) ? c2.correctLetter : string.Empty,
            weightRaw = weightByOption.TryGetValue(a.selectedOptionId, out var wt) ? (double)wt : 0.0,
            weightOfQuestionPercent = (totalByQuestion.TryGetValue(a.questionId, out var tot) && tot > 0) ? (double)(((weightByOption.TryGetValue(a.selectedOptionId, out var wtv) ? wtv : 0.0m) / tot) * 100.0m) : 0.0,
            weightDisplay = weightByOption.TryGetValue(a.selectedOptionId, out var wt2)
                ? (wt2 <= 1.0m ? ((double)wt2 * 100.0).ToString("0") + "%" : ((double)wt2).ToString("0"))
                : "0%",
            weightNormDisplay = (totalByQuestion.TryGetValue(a.questionId, out var tot2) && tot2 > 0)
                ? Math.Round((double)((weightByOption.TryGetValue(a.selectedOptionId, out var wtv2) ? wtv2 : 0.0m) / tot2 * 100.0m), 0)
                : 0.0,
            strandWeights = strandWeightsByOption.TryGetValue(a.selectedOptionId, out var sw) ? sw : new List<StrandWeightDto>()
        }).ToList();

        return Json(new { data = enriched });
    }

    private StudentStrandQuizSessionState GetState(Guid quizId)
        => StudentStrandQuizSessionState.FromJson(HttpContext.Session.GetString(SessionKeyPrefix + quizId));
    private void SaveState(Guid quizId, StudentStrandQuizSessionState state)
        => HttpContext.Session.SetString(SessionKeyPrefix + quizId, state.ToJson());

    // From assessment podium CTA
    public async Task<IActionResult> StartFromAssessment(Guid strandId, CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect!;

        var strand = await Db.Strands.FirstOrDefaultAsync(s => s.Id == strandId && s.IsActive, ct);
        if (strand == null) return NotFound();

        var quiz = await Db.StrandQuizzes.FirstOrDefaultAsync(q => q.StrandId == strandId && q.IsLive && q.IsActive, ct);
        if (quiz == null)
        {
            TempData["Error"] = "No active quiz is currently available for this strand.";
            return RedirectToAction("Index", "StudentResults");
        }

        HttpContext.Session.Remove(SessionKeyPrefix + quiz.Id); // reset
        var vm = new StudentStrandQuizLaunchViewModel
        {
            StrandId = strand.Id,
            StrandName = strand.Name,
            QuizId = quiz.Id,
            QuizTitle = quiz.Title,
            Description = quiz.Description,
            TotalQuestions = quiz.TotalQuestions,
            TimeLimitSeconds = quiz.TimeLimitSeconds
        };
        return View("Launch", vm);
    }

    // New: explicit retake endpoint to clear state and re-randomize
    public async Task<IActionResult> Retake(Guid quizId, CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect!;
        // Remove existing session state so Play() treats it as a brand new attempt
        HttpContext.Session.Remove(SessionKeyPrefix + quizId);
        // Also clear any temp flags
        TempData.Remove("ShieldUsed");
        TempData.Remove("ShieldGained");
        TempData.Remove("CorrectPrev");
        TempData.Remove("ShieldMessage");
        return RedirectToAction(nameof(Play), new { quizId });
    }

    public async Task<IActionResult> Play(Guid quizId, CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect!;

        var quiz = await Db.StrandQuizzes.Include(q => q.Strand).FirstOrDefaultAsync(q => q.Id == quizId && q.IsActive, ct);
        if (quiz == null) return NotFound();

        var questions = await Db.QuizQuestions.Where(q => q.StrandQuizId == quiz.Id && q.IsActive)
            .Select(q => q.Id).ToListAsync(ct);
        if (questions.Count == 0) return Problem("Quiz has no questions.");
        var state = GetState(quizId);
        if (state.QuestionOrder.Count == 0 || state.QuestionOrder.Count != questions.Count)
        {
            state.QuestionOrder = ShuffleList(questions, quiz.RandomizeQuestions);
            state.Shields = 2;
            state.CurrentStreak = 0;
            state.FinalAnswers.Clear();
            SaveState(quizId, state);
        }
        // Find first unanswered
        Guid? currentQ = state.QuestionOrder.FirstOrDefault(id => !state.FinalAnswers.ContainsKey(id));
        if (currentQ == Guid.Empty) return RedirectToAction(nameof(Results), new { quizId });

        var qEntity = await Db.QuizQuestions.FirstAsync(q => q.Id == currentQ, ct);
        var optionsRaw = await Db.QuizQuestionOptions.Where(o => o.QuizQuestionId == currentQ)
            .Select(o => new { o.Id, o.Text }).ToListAsync(ct);
        var optOrder = ShuffleList(optionsRaw.Select(o => o.Id).ToList(), quiz.RandomizeOptions);
        var vm = new StudentStrandQuizPlayViewModel
        {
            QuizId = quiz.Id,
            QuizTitle = quiz.Title,
            StrandName = quiz.Strand.Name,
            TotalQuestions = state.QuestionOrder.Count,
            CurrentIndex = state.QuestionOrder.IndexOf(currentQ.Value) + 1,
            AnsweredCount = state.FinalAnswers.Count,
            QuestionId = currentQ.Value,
            QuestionText = qEntity.Text,
            Options = optOrder.Select(id => new StudentStrandQuizPlayViewModel.OptionDto
            { OptionId = id, Text = optionsRaw.First(o => o.Id == id).Text }).ToList(),
            ShieldsRemaining = state.Shields,
            CurrentStreak = state.CurrentStreak,
            UsedShieldThisQuestion = TempData.ContainsKey("ShieldUsed"),
            GainedShieldThisQuestion = TempData.ContainsKey("ShieldGained")
        };
        // Consume the CorrectPrev flag so it only shows once after a correct answer
        if (TempData["CorrectPrev"] != null) ViewBag.CorrectPrev = true;
        if (TempData["IncorrectPrev"] != null) ViewBag.IncorrectPrev = true; // one-time
        return View("Play", vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Submit(Guid quizId, Guid questionId, Guid optionId, CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect!;
        var quiz = await Db.StrandQuizzes.FirstOrDefaultAsync(q => q.Id == quizId && q.IsActive, ct);
        if (quiz == null) return NotFound();
        var state = GetState(quizId);
        if (state.FinalAnswers.ContainsKey(questionId)) return RedirectToAction(nameof(Play), new { quizId });

        var correctOption = await Db.QuizQuestionOptions.FirstOrDefaultAsync(o => o.QuizQuestionId == questionId && o.IsCorrect, ct);
        if (correctOption == null) return Problem("Malformed quiz: no correct option.");

        if (correctOption.Id == optionId)
        {
            bool gainedShield = false;
            state.FinalAnswers[questionId] = optionId;
            state.CurrentStreak++;
            if (state.CurrentStreak > 0 && state.CurrentStreak % 5 == 0)
            {
                state.Shields++;
                gainedShield = true;
                TempData["ShieldGained"] = true;
            }
            SaveState(quizId, state);
            if (state.FinalAnswers.Count < state.QuestionOrder.Count)
            {
                TempData["CorrectPrev"] = true; // one-time correct animation
                return RedirectToAction(nameof(Play), new { quizId });
            }
            return RedirectToAction(nameof(Results), new { quizId });
        }
        else
        {
            // Incorrect answer paths clear correct flag and set incorrect flag for UI feedback
            TempData.Remove("CorrectPrev");
            TempData["IncorrectPrev"] = true;

            if (state.Shields > 0)
            {
                // Consume a shield but do NOT advance; student retries same question.
                state.Shields--;
                state.CurrentStreak = 0; // break streak
                SaveState(quizId, state);
                TempData["ShieldUsed"] = true; // still used to show alert (not toast)
                TempData["ShieldMessage"] = "Shield used! Try again. Shields left: " + state.Shields;
                return RedirectToAction(nameof(Play), new { quizId });
            }
            // No shields left -> record incorrect and advance
            state.FinalAnswers[questionId] = optionId;
            state.CurrentStreak = 0;
            SaveState(quizId, state);
            if (state.FinalAnswers.Count >= state.QuestionOrder.Count)
                return RedirectToAction(nameof(Results), new { quizId });
            return RedirectToAction(nameof(Play), new { quizId });
        }
    }

    // Added force flag to allow early finish ("Finish Now" button). When force=true we persist even if not all questions answered.
    public async Task<IActionResult> Results(Guid quizId, bool? gained, bool force = false, CancellationToken ct = default)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect!;
        var quiz = await Db.StrandQuizzes.Include(q => q.Strand).FirstOrDefaultAsync(q => q.Id == quizId && q.IsActive, ct);
        if (quiz == null) return NotFound();
        var state = GetState(quizId);
        if (state.QuestionOrder.Count == 0) return RedirectToAction(nameof(Play), new { quizId });
        var correctMap = await Db.QuizQuestionOptions.Where(o => state.QuestionOrder.Contains(o.QuizQuestionId) && o.IsCorrect)
            .ToDictionaryAsync(o => o.QuizQuestionId, o => o.Id, ct);
        int correct = state.FinalAnswers.Count(a => correctMap.ContainsKey(a.Key) && correctMap[a.Key] == a.Value);
        int total = state.QuestionOrder.Count;
        double percent = total > 0 ? (double)correct / total * 100d : 0d;
        var vm = new StudentStrandQuizResultsViewModel
        {
            QuizId = quiz.Id,
            QuizTitle = quiz.Title,
            StrandName = quiz.Strand.Name,
            TotalQuestions = total,
            CorrectAnswers = correct,
            ScorePercent = Math.Round(percent, 2)
        };
        ViewBag.ShieldsLeft = state.Shields;
        ViewBag.GainedShield = gained == true || TempData.ContainsKey("ShieldGained");

        // Persist attempt: original behavior only saved when all answered. Allow saving when force=true (Finish Now)
        if (student != null && total > 0 && (state.FinalAnswers.Count == total || force))
        {
            int maxStreak = state.CurrentStreak; // basic heuristic
            await _quizResultService.RecordAsync(student.Id, quiz.Id, total, correct, state.Shields, maxStreak, ct);
            // If user finished early, clear session so they can't resume answering remaining questions for same attempt
            if (force && state.FinalAnswers.Count < total)
            {
                HttpContext.Session.Remove(SessionKeyPrefix + quizId);
            }
        }

        return View("Results", vm);
    }

    private static List<Guid> ShuffleList(List<Guid> list, bool doShuffle)
    {
        if (!doShuffle) return list.ToList();
        var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
        var arr = list.ToList();
        for (int i = arr.Count - 1; i > 0; i--)
        {
            var b = new byte[4]; rng.GetBytes(b); int r = BitConverter.ToInt32(b, 0) & int.MaxValue; int j = r % (i + 1); (arr[i], arr[j]) = (arr[j], arr[i]);
        }
        return arr;
    }
}
