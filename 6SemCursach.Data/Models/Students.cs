
using System.Collections.Generic;

namespace _6SemCursach.Data.Models
{
    public class Students
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public List<CoursStud> CoursStud { get; set; }
        public Students()
        {
            CoursStud = new List<CoursStud>();
        }

        public int IDUser { get; set; }
        public Users User { get; set; }
    }
}
