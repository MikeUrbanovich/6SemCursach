using _6SemCursach.Data.Models;
using _6SemCursach.BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _6SemCursach.BusinessLogic.Services
{
    public class ServiceCourse: ICourse
    {
        private readonly ApplicationContext _context;
        private readonly IUser _user;

        public ServiceCourse(
            ApplicationContext context,
            IUser user)
        {
            _context = context;
            _user = user;
        }
        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses;
        }
       
        public void AddCourse(NewCourse newCourse)
        {
            var course = new Course()
            {
                Title = newCourse.Title,
                Price = newCourse.Price
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void BuyCourse(Course course, string email)
        {
            var currentlyUser = _context.Users
                .Include(u => u.Student)
                .ThenInclude(s => s.CoursStud)
                .FirstOrDefault(u => u.Email == email);
            
            if(currentlyUser.Student.Money-(double)course.Price>0)
            {
                currentlyUser.Student.Money -= (double) course.Price;

                currentlyUser
                    .Student.CoursStud.Add(
                        new CoursStud
                        {
                            CourseFK = course.CourseId,
                            StudentFK = currentlyUser.Student.StudentId
                        });
            }
           
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

        public void DeleteCourse(int idCourse)
        {
            var course = _context.Courses
                .FirstOrDefault(c => c.CourseId == idCourse);

            if(course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public bool CourseExists(string title)
        {
            var course = _context.Courses
                .FirstOrDefault(c => c.Title == title);

            return course != null;
        }

        public List<Course> GetCourseForCurrentlyStudent(string email)
        { 
            var currentlyUser = _context.Users
                .Include(u => u.Student)
                .FirstOrDefault(u => u.Email == email);

            var student = _context.Students
                .Include(s => s.CoursStud)
                .ThenInclude(s => s.Course)
                .FirstOrDefault(s => s.StudentId == currentlyUser.Student.StudentId);


            return student.CoursStud.Select(c => c.Course).ToList();
        }

        public void AddCourseForTeacher(Course course, string email)
        {
            var currentlyUser = _context.Users
                .Include(u => u.Teacher)
                .FirstOrDefault(u => u.Email == email);

            var existingCourse = _context.Courses
                .FirstOrDefault(c => c.CourseId == course.CourseId);

            if (currentlyUser != null && existingCourse != null)
                existingCourse.TeacherID = currentlyUser.Teacher.TeacherId;

            _context.SaveChanges();
        }

        public List<CourseForStudent> GetListCourseForStudent(string email)
        {
            var courseForCurrentlyStudent = GetCourseForCurrentlyStudent(email);

            var courseForStudent = new List<CourseForStudent>();

            foreach (var course in _context.Courses)
            {
                var model = new CourseForStudent
                {
                    Course = course,
                    CourseIsListBought = courseForCurrentlyStudent
                        .FirstOrDefault(c => c.CourseId == course.CourseId) != null
                };

                courseForStudent.Add(model);
            }
            return courseForStudent;
        }
    }
}
