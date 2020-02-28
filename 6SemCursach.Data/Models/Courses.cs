using System;
using System.Collections.Generic;
using System.Text;

namespace _6SemCursach.Data.Models
{
    public class Courses
    {
        public int CoursId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int IDTeacher { get; set; }
    }
}
