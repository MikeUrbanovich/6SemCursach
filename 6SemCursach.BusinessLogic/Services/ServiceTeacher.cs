using _6SemCursach.BusinessLogic.Models;
using _6SemCursach.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _6SemCursach.BusinessLogic.Services
{
    public class ServiceTeacher : ITeacher
    {
        private readonly ApplicationContext _context;
        public ServiceTeacher(ApplicationContext context)
        {
            _context = context;
        }
        public void AddTeacher(Register register)
        {
            var role = _context.Roles.
               Where(r => r.Title == register.Role)
               .FirstOrDefault();
            var user = new User
            {
                Email = register.Email,
                Password = register.Password,
                Role = role,
                Teacher = new Teacher
                {
                    Name = register.Name
                }
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            throw new NotImplementedException();
        }
    }
}
