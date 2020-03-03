using System.Collections.Generic;

namespace _6SemCursach.Data.Models
{
    public class Semester
    {
        public Semester()
        { }
        public int SemesterId { get; set; }
        public string Title { get; set; }

        public List<CoursStud> CoursStud { get; set; }
    }
}
