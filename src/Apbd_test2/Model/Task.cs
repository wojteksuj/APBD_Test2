using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;
public class Task 
{ 
    public int Id { get; set; } 
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public ICollection<Record> Records { get; set; } 
}

