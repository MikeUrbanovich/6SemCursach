using System.Collections.Generic;

namespace _6SemCursach.Data.Models
{
    public class Course
    {
        public Course()
        {
            CoursStud = new List<CoursStud>();
        }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public int TeacherID { get; set; }

        public List<CoursStud> CoursStud { get; set; }
       
    }
}
