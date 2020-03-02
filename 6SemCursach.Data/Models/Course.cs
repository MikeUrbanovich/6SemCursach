using System.Collections.Generic;

namespace _6SemCursach.Data.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public int IDTeacher { get; set; }
        public Teacher Teacher { get; set; }

        public List<CoursStud> CoursStud { get; set; }
        public Course()
        {
            CoursStud = new List<CoursStud>();
        }
    }
}
