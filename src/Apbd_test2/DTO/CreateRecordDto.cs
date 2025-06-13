using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO;

public class CreateRecordDto
{
    [Required]
    public int StudentId { get; set; }
    [Required]
    public int ProgrammingLanguageId { get; set; }
    [Required]
    public int TaskId { get; set; }

    [Required, MaxLength(50)]
    public string TaskName { get; set; }
    [Required, MaxLength(50)]
    public string TaskDescription { get; set; }
    [Required]
    public decimal ExecutionTime { get; set; }
}