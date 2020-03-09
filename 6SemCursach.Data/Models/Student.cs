
using System.Collections.Generic;

namespace _6SemCursach.Data.Models
{
    public class Student
    {
        public Student()
        {
            CoursStud = new List<CoursStud>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }

        public List<CoursStud> CoursStud { get; set; }
       
        public int UserFK { get; set; }
        public User User { get; set; }
    }
}
