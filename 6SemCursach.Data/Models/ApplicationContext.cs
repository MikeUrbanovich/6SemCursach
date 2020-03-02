using Microsoft.EntityFrameworkCore;

namespace _6SemCursach.Data.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Semesters> Semesters { get; set; }
        
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoursStud>()
                .HasKey(t => new
                {
                    t.CourseId,
                    t.StudentId
                }
                );

            modelBuilder.Entity<CoursStud>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.CoursStud)
                .HasForeignKey(cs => cs.StudentId);

            modelBuilder.Entity<CoursStud>()
               .HasOne(cs => cs.Course)
               .WithMany(c => c.CoursStud)
               .HasForeignKey(cs => cs.CourseId);
        }
        
    }
}
