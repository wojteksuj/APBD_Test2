using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using Task = WebApplication1.Model.Task;

namespace WebApplication1.DAL;

public class RecordManiaContext : DbContext
{
    public RecordManiaContext(DbContextOptions<RecordManiaContext> options)
        : base(options) {}

    public DbSet<Student> Students { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Record> Records { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Student)
                .WithMany(s => s.Records)
                .HasForeignKey(e => e.StudentId);

            entity.HasOne(e => e.Language)
                .WithMany(p => p.Records)
                .HasForeignKey(e => e.LanguageId);

            entity.HasOne(e => e.Task)
                .WithMany(t => t.Records)
                .HasForeignKey(e => e.TaskId);
        });
    }
}