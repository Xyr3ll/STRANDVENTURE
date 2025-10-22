using System.Threading;
using System.Threading.Tasks;

namespace STRANDVENTURE.Services;

public record AssessmentBulkImportReport(
    int QuestionsCreated,
    int QuestionsUpdated,
    int QuestionDuplicatesSkipped,
    int OptionsCreated,
    int WeightsCreated,
    int RowsParsed,
    List<string> Errors);

public interface IAssessmentBulkImportService
{
    Task<AssessmentBulkImportReport> ImportAsync(Stream csvStream, Guid employeeId, bool upsert, CancellationToken ct = default);
}