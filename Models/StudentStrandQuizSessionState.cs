using System.Text.Json;

namespace STRANDVENTURE.Models;

// Stored in session per quiz to manage shields and streaks
public class StudentStrandQuizSessionState
{
    public List<Guid> QuestionOrder { get; set; } = new();
    // Answers only recorded when finalized (no shield preventing)
    public Dictionary<Guid, Guid> FinalAnswers { get; set; } = new();
    public int Shields { get; set; } = 2; // initial
    public int CurrentStreak { get; set; } = 0; // consecutive correct without shield usage

    public static StudentStrandQuizSessionState FromJson(string? json)
        => string.IsNullOrWhiteSpace(json) ? new StudentStrandQuizSessionState() : (JsonSerializer.Deserialize<StudentStrandQuizSessionState>(json) ?? new StudentStrandQuizSessionState());
    public string ToJson() => JsonSerializer.Serialize(this);
}
