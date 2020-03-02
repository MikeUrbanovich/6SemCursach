
namespace _6SemCursach.Data.Models
{
    public class CoursStud
    {
        public int CourseId { get; set; }
        public Courses Course { get; set; }

        public int StudentId { get; set; }
        public Students Student { get; set; }

        public int SemesterId { get; set; }
        public Semesters Semester { get; set; }
    }
}
