using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.DTO;
using WebApplication1.Model;
using Task = System.Threading.Tasks.Task;

namespace WebApplication1.Services;

public class RecordManiaService : IRecordManiaService
    {
        private readonly RecordManiaContext _context;

        public RecordManiaService(RecordManiaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecordDto>> GetRecordsAsync(DateTime? createdAfter, int? programmingLanguageId, int? taskId)
        {
            var query = _context.Records
                .Include(r => r.Student)
                .Include(r => r.Language)
                .Include(r => r.Task)
                .AsQueryable();

            if (createdAfter.HasValue)
                query = query.Where(r => r.CreatedAt >= createdAfter.Value);

            if (programmingLanguageId.HasValue)
                query = query.Where(r => r.LanguageId == programmingLanguageId.Value);

            if (taskId.HasValue)
                query = query.Where(r => r.TaskId == taskId.Value);

            query = query
                .OrderByDescending(r => r.CreatedAt)
                .ThenBy(r => r.Student.LastName);

            return await query.Select(r => new RecordDto
            {
                Id = r.Id,
                ExecutionTime = r.ExecutionTime,
                Created = r.CreatedAt,
                Student = new StudentDto
                {
                    Id = r.Student.Id,
                    FirstName = r.Student.FirstName,
                    LastName = r.Student.LastName,
                    Email = r.Student.Email
                },
                Language = new LanguageDto
                {
                    Id = r.Language.Id,
                    Name = r.Language.Name
                },
                Task = new TaskDto
                {
                    Id = r.Task.Id,
                    Name = r.Task.Name,
                    Description = r.Task.Description
                }
            }).ToListAsync();
        }


        public async Task AddRecordAsync(CreateRecordDto dto)
        {
            var student = await _context.Students.FindAsync(dto.StudentId);
            if (student == null)
                throw new ArgumentException("Student not found!!");

            var language = await _context.Languages.FindAsync(dto.ProgrammingLanguageId);
            if (language == null)
                throw new ArgumentException("Language not found!!");

            WebApplication1.Model.Task task = await _context.Tasks.FindAsync(dto.TaskId);
            if (task == null)
            {
                task = new WebApplication1.Model.Task
                {
                    Name = dto.TaskName,
                    Description = dto.TaskDescription
                };
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();
            }

            var record = new Record
            {
                CreatedAt = DateTime.UtcNow,
                StudentId = dto.StudentId,
                LanguageId = dto.ProgrammingLanguageId,
                TaskId = task.Id
            };

            _context.Records.Add(record);
            await _context.SaveChangesAsync();
        }
    }