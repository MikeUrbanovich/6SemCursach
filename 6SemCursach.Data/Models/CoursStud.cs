
namespace _6SemCursach.Data.Models
{
    public class CoursStud
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
    }
}
