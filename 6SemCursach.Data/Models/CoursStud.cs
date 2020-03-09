
namespace _6SemCursach.Data.Models
{
    public class CoursStud
    {
        public int CourseFK { get; set; }
        public Course Course { get; set; }

        public int StudentFK { get; set; }
        public Student Student { get; set; }

        public int SemesterFK { get; set; }
        public Semester Semester { get; set; }
    }
}
