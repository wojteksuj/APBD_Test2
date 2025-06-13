using WebApplication1.DTO;

namespace WebApplication1.Services;


public interface IRecordManiaService 
{ 
    Task<IEnumerable<RecordDto>> GetRecordsAsync(DateTime? createdAfter, int? programmingLanguageId, int? taskId);
    Task AddRecordAsync(CreateRecordDto dto); 
}
