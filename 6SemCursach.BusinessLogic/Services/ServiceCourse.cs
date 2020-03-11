using _6SemCursach.Data.Models;
using _6SemCursach.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;

namespace _6SemCursach.BusinessLogic.Services
{
    public class ServiceCourse: ICourse
    {
        private readonly ApplicationContext _context;

        public ServiceCourse(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses;
        }
       
        public void AddCourse(NewCourse newcourse)
        {
            var course = new Course()
            {
                Title = newcourse.Title,
                Price = newcourse.Price
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void AddCourseWithFile(List<NewCourse> listNewCourses)
        {
            var listCourse = new List<Course>();
            foreach(var course in listNewCourses)
            {
                listCourse
                    .Add(
                    new Course
                    {
                        Title = course.Title,
                        Price = course.Price
                    });
                
            }

            _context.Courses.AddRange(listCourse);
            _context.SaveChanges();
        }

        public void DeleteCourse(int idCource)
        {
            var cource = _context.Courses
                .Where(c => c.CourseId == idCource)
                .FirstOrDefault();
            if(cource != null)
            {
                _context.Courses.Remove(cource);
                _context.SaveChanges();
            }
        }

        public bool CourseExists(string title)
        {
            var cource = _context.Courses
                .Where(c => c.Title == title)
                .FirstOrDefault();
            if (cource == null)
            {
                return false;
            }
            else
            {
                return true;
            }  
        }
    }
}
