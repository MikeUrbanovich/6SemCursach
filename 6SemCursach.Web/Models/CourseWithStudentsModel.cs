using System.Collections.Generic;
using _6SemCursach.Data.Models;

namespace _6SemCursach.Web.Models
{
    public class CourseWithStudentsModel
    {
        public Course Course { get; set; }
        public List<Student> Students { get; set; }
    }
}
