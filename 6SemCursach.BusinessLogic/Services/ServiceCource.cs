using _6SemCursach.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace _6SemCursach.BusinessLogic.Services
{
    public class ServiceCource: ICource
    {
        private readonly ApplicationContext _context;

        public ServiceCource(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetAllCources()
        {
            return _context.Courses;
        }
       
        public void AddCource(Course cource)
        {
            _context.Courses.Add(cource);
            _context.SaveChanges();
        }

        public void DeleteCource(int idCource)
        {
            var cource = _context.Courses
                .Where(c => c.CourseId == idCource)
                .FirstOrDefault();
            if(cource != null)
            {
                _context.Courses.Remove(cource);
                _context.SaveChanges();
            }
           
        }
    }
}
