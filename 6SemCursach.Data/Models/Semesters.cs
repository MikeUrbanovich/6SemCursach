using System.Collections.Generic;

namespace _6SemCursach.Data.Models
{
    public class Semesters
    {
        public int SemesterId { get; set; }
        public string Title { get; set; }

        public List<CoursStud> CoursStud { get; set; }
    }
}
