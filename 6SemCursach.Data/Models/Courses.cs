using System.Collections.Generic;

namespace _6SemCursach.Data.Models
{
    public class Courses
    {
        public int CoursId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }


        public List<CoursStud> CoursStud { get; set; }
        public Courses()
        {
            CoursStud = new List<CoursStud>();
        }

        public int IDTeacher { get; set; }
        public Teachers Teacher { get; set; }
    }
}
