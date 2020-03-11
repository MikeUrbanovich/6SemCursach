using _6SemCursach.BusinessLogic.Models;
using _6SemCursach.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _6SemCursach.BusinessLogic.Services
{
    public interface IUser
    {
        IEnumerable<User> GetAllUsers();
        //Task<UserAccount> GetUser(string email, string password);
        UserAccount GetUser(string email, string password);
        //Task<UserAccount> GetUser(string email);
        UserAccount GetUser(string email);
        //void AddUser(Register user);
    }
}
