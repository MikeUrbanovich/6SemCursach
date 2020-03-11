using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _6SemCursach.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace _6SemCursach.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourse _course;

        public CourseController(ICourse course)
        {
            _course = course;
        }
        public IActionResult ListCourses()
        {
            return View(_course.GetAllCourses());
        }
    }
}