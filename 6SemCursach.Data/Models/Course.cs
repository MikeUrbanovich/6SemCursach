﻿using System.Collections.Generic;

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
        public decimal Price { get; set; }

        public int TeacherFK { get; set; }
        public Teacher Teacher { get; set; }

        public List<CoursStud> CoursStud { get; set; }
       
    }
}
