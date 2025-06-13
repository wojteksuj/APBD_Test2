using System.ComponentModel.DataAnnotations;
using WebApplication1.Model;

namespace WebApplication1.DTO;

public class RecordDto
{
    public int Id { get; set; }
    [Required]
    public LanguageDto Language { get; set; }
    [Required]
    public TaskDto Task { get; set; }
    [Required]
    public StudentDto Student { get; set; }

    public decimal ExecutionTime { get; set; }

    public DateTime Created { get; set; }
}

public class LanguageDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class TaskDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}