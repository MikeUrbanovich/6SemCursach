using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _6SemCursach.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace _6SemCursach.Web.Controllers
{
    public class CourceController : Controller
    {
        private readonly ICourse _course;

        public CourceController(ICourse course)
        {
            _course = course;
        }
        public IActionResult ListCources()
        {
            return View(_course.GetAllCources());
        }
    }
}