using Microsoft.EntityFrameworkCore;

namespace StudentsDataSystem.Models
{
    public class StudentsSystemContext : DbContext
    {
        public StudentsSystemContext(DbContextOptions<StudentsSystemContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(s => s.id);
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
