namespace STRANDVENTURE.Models;

public class StudentStrandQuizPlayViewModel
{
    public Guid QuizId { get; set; }
    public string QuizTitle { get; set; } = string.Empty;
    public string StrandName { get; set; } = string.Empty;

    public int TotalQuestions { get; set; }
    public int CurrentIndex { get; set; } // 1-based for display
    public int AnsweredCount { get; set; }

    public Guid QuestionId { get; set; }
    public string QuestionText { get; set; } = string.Empty;

    public List<OptionDto> Options { get; set; } = new();

    // Gamification
    public int ShieldsRemaining { get; set; }
    public int CurrentStreak { get; set; }
    public bool UsedShieldThisQuestion { get; set; }
    public bool GainedShieldThisQuestion { get; set; }

    public class OptionDto
    {
        public Guid OptionId { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
