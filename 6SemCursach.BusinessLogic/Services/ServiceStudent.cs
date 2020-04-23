using _6SemCursach.BusinessLogic.Models;
using _6SemCursach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _6SemCursach.BusinessLogic.Services
{
    public class ServiceStudent: IStudent
    {
        private readonly ApplicationContext _context;
        public ServiceStudent(ApplicationContext context)
        {
            _context = context;
        }
        public void AddStudent(Register register)
        {
            var role = _context.Roles
                .FirstOrDefault(r => r.Title == register.Role);

            var user = new User
            {
                Email = register.Email,
                Password = register.Password,
                Role = role,
                Student = new Student
                {
                    Name = register.Name
                }
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public User GetStudent(string email)
        {
            var currentlyUser = _context.Users
                .Include(u => u.Student)
                .FirstOrDefault(u => u.Email == email);

            return currentlyUser;
        }

        public List<Student> GetStudentsForCourse(Course course)
        {
            var courseWithStudents = _context.Courses
                .Include(c => c.CoursStud)
                .ThenInclude(c => c.Student)
                .FirstOrDefault(c => c.CourseId == course.CourseId);

            var students = courseWithStudents.CoursStud.Select(c => c.Student).ToList();

            return students;
        }
    }
}
