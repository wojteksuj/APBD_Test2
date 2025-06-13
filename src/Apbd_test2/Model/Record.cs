using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace WebApplication1.Model;

public class Record 
{ 
    public int Id { get; set; } 
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public decimal ExecutionTime { get; set; }
    [Required]
    public int StudentId { get; set; } 
    public Student Student { get; set; }
    [Required]
    
    public int LanguageId { get; set; }
    public Language Language { get; set; }
    
    [Required]
    public int TaskId { get; set; } 
    public Task Task { get; set; }
    
    
    
}

