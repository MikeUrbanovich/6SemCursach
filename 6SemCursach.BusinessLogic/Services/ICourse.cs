using _6SemCursach.BusinessLogic.Models;
using _6SemCursach.Data.Models;
using System.Collections.Generic;

namespace _6SemCursach.BusinessLogic.Services
{
    public interface ICourse
    {
        IEnumerable<Course> GetAllCources();
        void AddCourse(NewCourse course);
        void DeleteCourse(int idCourse);
        bool CourseExists(string title);
    }
}
