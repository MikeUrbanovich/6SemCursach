using _6SemCursach.BusinessLogic.Models;
using _6SemCursach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var role = _context.Roles.
                Where(r => r.Title == register.Role)
                .FirstOrDefault();
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
    }
}
