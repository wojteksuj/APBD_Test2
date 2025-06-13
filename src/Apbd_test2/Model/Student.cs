using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class Student
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }

    public ICollection<Record> Records { get; set; }
}