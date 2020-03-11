using _6SemCursach.BusinessLogic.Models;
using _6SemCursach.Data.Models;
using System.Collections.Generic;

namespace _6SemCursach.BusinessLogic.Services
{
    public interface IStudent
    {
        IEnumerable<Student> GetAllStudents();
        //Task<UserAccount> GetUser(string email, string password);
        //Task<UserAccount> GetUser(string email);
        void AddStudent(Register student);
    }
}
