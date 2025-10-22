namespace STRANDVENTURE.Models;

public class StudentDashboardViewModel
{
    public Student Student { get; set; } = null!;
    public int TotalAttempts { get; set; }
    public DateTime? LastAttemptAt { get; set; }
    public bool HasHonoredResult { get; set; }
    public List<StrandSummary> Strands { get; set; } = new();
    public class StrandSummary
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

public class StudentAssessmentViewModel
{
    public Student Student { get; set; } = null!;
    public bool CanStartNewAttempt { get; set; }
    public int ExistingAttempts { get; set; }
    public Guid? ActiveAttemptId { get; set; }
}

public class StudentAssessmentTakeViewModel
{
    public Guid AttemptId { get; set; }
    public int TotalQuestions { get; set; }
    public int AnsweredQuestions { get; set; }
    public QuestionDto? CurrentQuestion { get; set; }
    public List<StrandScoreDto> StrandScores { get; set; } = new();
    public bool IsCompleted => AnsweredQuestions >= TotalQuestions || CurrentQuestion == null;

    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public List<OptionDto> Options { get; set; } = new();
    }
    public class OptionDto
    {
        public Guid Id { get; set; }
        public string Letter { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
    public class StrandScoreDto
    {
        public Guid StrandId { get; set; }
        public string StrandName { get; set; } = string.Empty;
        public decimal ScorePercent { get; set; }
        public string Color { get; set; } = "#000000"; // Added for UI coloring
    }
}

public class StudentResultsViewModel
{
    public Student Student { get; set; } = null!;
    public Guid? HonoredAttemptId { get; set; }
    public List<ResultItem> Attempts { get; set; } = new();

    // New: detailed honored attempt strand slices for chart
    public List<StrandSlice> HonoredScores { get; set; } = new();

    // New: recommended strand (from first honored result)
    public StrandRecommendation? Recommendation { get; set; }

    // New: all strands (includes percent from honored attempt if available)
    public List<StrandCard> AllStrands { get; set; } = new();

    public bool HasHonored => HonoredAttemptId.HasValue && Recommendation != null;

    public class ResultItem
    {
        public Guid AttemptId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public bool IsHonored { get; set; }
        public Dictionary<string, decimal> StrandScores { get; set; } = new();
        public decimal? TotalScorePercent { get; set; }
    }

    public class StrandSlice
    {
        public Guid StrandId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Percent { get; set; }
        public string Color { get; set; } = "#1e6bff";
    }

    public class StrandRecommendation
    {
        public Guid StrandId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Percent { get; set; }
        public string Color { get; set; } = "#1e6bff";
        public DateTime FinalizedAt { get; set; }
    }

    public class StrandCard
    {
        public Guid StrandId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Color { get; set; } = "#1e6bff";
        public decimal? Percent { get; set; }  // null if not in honored attempt yet
        public string? Badge { get; set; } // Top 1/2/3 badge
    }
}

public class StudentSettingsViewModel
{
    public Student Student { get; set; } = null!;
    public string? SuccessMessage { get; set; }
    public string? ErrorMessage { get; set; }
    public ChangePasswordInput PasswordChange { get; set; } = new();

    public class ChangePasswordInput
    {
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

public class StudentAchievementsViewModel
{
    public Student Student { get; set; } = null!;
    public List<StrandAchievement> TopStrands { get; set; } = new();

    public class StrandAchievement
    {
        public string StrandName { get; set; } = string.Empty;
        public decimal AverageScore { get; set; }
        public int AttemptsCount { get; set; }
    }
}

// Added: quiz results view model for standalone strand quiz
public class StudentStrandQuizResultsViewModel
{
    public Guid QuizId { get; set; }
    public string QuizTitle { get; set; } = string.Empty;
    public string StrandName { get; set; } = string.Empty;
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public double ScorePercent { get; set; } // 0 - 100
}
