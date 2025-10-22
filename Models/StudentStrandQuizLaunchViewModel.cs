namespace STRANDVENTURE.Models;

public class StudentStrandQuizLaunchViewModel
{
    public Guid StrandId { get; set; }
    public string StrandName { get; set; } = string.Empty;

    public Guid QuizId { get; set; }
    public string QuizTitle { get; set; } = string.Empty;
    public string? Description { get; set; }

    public int TotalQuestions { get; set; }
    public int? TimeLimitSeconds { get; set; }
}
