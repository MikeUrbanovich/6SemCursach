using _6SemCursach.BusinessLogic.Models;
using _6SemCursach.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6SemCursach.BusinessLogic.Services
{
    public class ServiceUser: IUser
    {
        private readonly ApplicationContext _context;
        public ServiceUser(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public UserAccount GetUser(string email, string password)
        {
            var user = _context.Users
                .Where(u => u.Email == email && u.Password == password)
                .Include(u => u.Role)
                .FirstOrDefault();
            if(user == null)
            {
                return null;
            }
            var account = new UserAccount()
            {
                Id = user.UserId,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role.Title
            };
            return account;
        }

        public UserAccount GetUser(string email)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return null;
            }

            var account = new UserAccount()
            {
                Id = user.UserId,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role.Title
            };
            return account;
        }

        //public void AddUser(Register user)
        //{
        //    _context.Users.Add(user);
        //    _context.SaveChanges();
        //}

        //public void DeleteCource(int idCource)
        //{
        //    var cource = _context.Courses
        //        .Where(c => c.CourseId == idCource)
        //        .FirstOrDefault();
        //    if (cource != null)
        //    {
        //        _context.Courses.Remove(cource);
        //        _context.SaveChanges();
        //    }

        //}
    }
}
