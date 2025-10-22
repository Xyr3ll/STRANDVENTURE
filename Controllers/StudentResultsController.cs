using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Security;
using STRANDVENTURE.Services;

namespace STRANDVENTURE.Controllers;

public class StudentResultsController : StudentPortalControllerBase
{
    public StudentResultsController(ApplicationDbContext db, IStudentService studentService, IPasswordHasher passwordHasher)
        : base(db, studentService, passwordHasher) { }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect;

        // Original honored / assessment logic kept
        var honored = await Db.StudentAssessmentResults
            .Include(r => r.RecommendedStrand)
            .FirstOrDefaultAsync(r => r.StudentId == student.Id, ct);
        Guid? honoredAttemptId = honored?.AttemptId;

        var attempts = await Db.StudentAssessmentAttempts
            .Where(a => a.StudentId == student.Id)
            .OrderBy(a => a.AttemptNumber)
            .Select(a => new { a.Id, a.StartedAt, a.CompletedAt, a.IsCompleted, a.TotalScorePercent })
            .ToListAsync(ct);
        var attemptIds = attempts.Select(a => a.Id).ToList();
        var scores = await Db.StudentAssessmentStrandScores
            .Where(s => attemptIds.Contains(s.AttemptId))
            .Join(Db.Strands, s => s.StrandId, st => st.Id, (s, st) => new { s.AttemptId, st.Name, s.ScorePercent })
            .ToListAsync(ct);

        var vm = new StudentResultsViewModel { Student = student, HonoredAttemptId = honoredAttemptId };
        foreach (var a in attempts)
        {
            var item = new StudentResultsViewModel.ResultItem
            {
                AttemptId = a.Id,
                StartedAt = a.StartedAt,
                CompletedAt = a.CompletedAt,
                TotalScorePercent = a.TotalScorePercent,
                IsHonored = honoredAttemptId.HasValue && honoredAttemptId.Value == a.Id
            };
            item.StrandScores = scores.Where(s => s.AttemptId == a.Id)
                .OrderByDescending(s => s.ScorePercent)
                .ToDictionary(s => s.Name, s => s.ScorePercent);
            vm.Attempts.Add(item);
        }

        if (honoredAttemptId.HasValue)
        {
            var honoredSlices = await Db.StudentAssessmentStrandScores
                .Where(s => s.AttemptId == honoredAttemptId.Value)
                .Join(Db.Strands, s => s.StrandId, st => st.Id,
                    (s, st) => new StudentResultsViewModel.StrandSlice
                    {
                        StrandId = st.Id,
                        Name = st.Name,
                        Percent = s.ScorePercent,
                        Color = string.IsNullOrWhiteSpace(st.Color) ? "#1e6bff" : st.Color
                    })
                .OrderByDescending(x => x.Percent)
                .ToListAsync(ct);
            vm.HonoredScores = honoredSlices;
            if (honored?.RecommendedStrandId != null)
            {
                var recSlice = honoredSlices.FirstOrDefault(x => x.StrandId == honored.RecommendedStrandId);
                vm.Recommendation = new StudentResultsViewModel.StrandRecommendation
                {
                    StrandId = honored.RecommendedStrandId.Value,
                    Name = honored.RecommendedStrand?.Name ?? "Strand",
                    Description = honored.FeedbackDescription ?? StrandResultDescriptions.GetRandomDescription(honored.RecommendedStrand?.Name ?? "Strand"),                    Percent = recSlice?.Percent ?? 0m,
                    Color = honored.RecommendedStrand?.Color ?? "#1e6bff",
                    FinalizedAt = honored.FinalizedAt
                };
            }
        }

        var allStrands = await Db.Strands.OrderBy(s => s.Name).ToListAsync(ct);
        var honoredDict = vm.HonoredScores.ToDictionary(s => s.StrandId, s => s.Percent);
        vm.AllStrands = allStrands.Select(s => new StudentResultsViewModel.StrandCard
        {
            StrandId = s.Id,
            Name = s.Name,
            Description = s.Description ?? "",
            Color = string.IsNullOrWhiteSpace(s.Color) ? "#1e6bff" : s.Color,
            Percent = honoredDict.TryGetValue(s.Id, out var p) ? p : null
        }).ToList();

        // Assign badges to top 3 by percentage
        var sorted = vm.AllStrands.OrderByDescending(x => x.Percent ?? 0).ToList();
        for (int i = 0; i < sorted.Count; i++)
        {
            if (i == 0) sorted[i].Badge = "Top 1"; // 🥇
            else if (i == 1) sorted[i].Badge = "Top 2"; // 🥈
            else if (i == 2) sorted[i].Badge = "Top 3"; // 🥉
            else sorted[i].Badge = null;
        }

        // Quiz results (augment via ViewData to avoid changing existing VM structure)
        var quizRows = await Db.StudentStrandQuizResults
            .Where(r => r.StudentId == student.Id)
            .OrderByDescending(r => r.CompletedAt)
            .ThenByDescending(r => r.AttemptNumber)
            .Take(25)
            .Join(Db.StrandQuizzes.Include(q => q.Strand), r => r.StrandQuizId, q => q.Id, (r, q) => new
            {
                r.Id,
                QuizId = q.Id,
                q.Title,
                StrandName = q.Strand.Name,
                r.AttemptNumber,
                r.TotalQuestions,
                r.CorrectAnswers,
                r.ScorePercent,
                r.ShieldsRemaining,
                r.MaxStreakAchieved,
                r.CompletedAt
            }).ToListAsync(ct);
        ViewData["QuizResultsJson"] = System.Text.Json.JsonSerializer.Serialize(quizRows); // optional for client use
        ViewBag.QuizResults = quizRows; // used by view

        return View(vm);
    }
}
