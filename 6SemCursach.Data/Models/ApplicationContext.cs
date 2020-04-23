using Microsoft.EntityFrameworkCore;

namespace _6SemCursach.Data.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Semester> Semesters { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ZENBOOK-UX510UX;Initial Catalog=db6SemCursachBibd;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Teachers-Courses
            //modelBuilder.Entity<Teacher>()
            //.HasOne(t => t.Course)
            //.WithOne(c => c.Teacher)
            //.HasForeignKey<Course>(c => c.TeacherFK);

            //Teachers-User
            modelBuilder.Entity<User>()
            .HasOne(u => u.Teacher)
            .WithOne(t => t.User)
            .HasForeignKey<Teacher>(t => t.UserFK);

            //Students-User
            modelBuilder.Entity<User>()
            .HasOne(u => u.Student)
            .WithOne(s => s.User)
            .HasForeignKey<Student>(s => s.UserFK);

            //User-Roles
            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleFK);

            //Sem-CourseStude
            //modelBuilder.Entity<CoursStud>()
            //.HasOne(c => c.Semester)
            //.WithMany(s => s.CoursStud)
            //.HasForeignKey(c => c.SemesterFK);

            //Many-to-many
            modelBuilder.Entity<CoursStud>()
                .HasKey(t => new
                {
                    t.CourseFK,
                    t.StudentFK
                }
                );

            modelBuilder.Entity<CoursStud>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.CoursStud)
                .HasForeignKey(cs => cs.StudentFK)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CoursStud>()
               .HasOne(cs => cs.Course)
               .WithMany(c => c.CoursStud)
               .HasForeignKey(cs => cs.CourseFK)
               .OnDelete(DeleteBehavior.Restrict); ;
        }



    }
}
