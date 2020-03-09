using _6SemCursach.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6SemCursach.BusinessLogic.Services
{
    public interface ICource
    {
        IEnumerable<Course> GetAllCources();
        void AddCource(Course cource);
        void DeleteCource(int idCource);
    }
}
