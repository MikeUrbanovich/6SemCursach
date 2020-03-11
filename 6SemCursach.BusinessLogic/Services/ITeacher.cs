using _6SemCursach.BusinessLogic.Models;
using _6SemCursach.Data.Models;
using System.Collections.Generic;

namespace _6SemCursach.BusinessLogic.Services
{
    public interface ITeacher
    {
        IEnumerable<Teacher> GetAllTeachers();
        //Task<UserAccount> GetUser(string email, string password);
        //Task<UserAccount> GetUser(string email);
        void AddTeacher(Register teacher);
    }
}
