using System.Threading.Tasks;
using _6SemCursach.BusinessLogic.Models;
using _6SemCursach.BusinessLogic.Services;
using _6SemCursach.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _6SemCursach.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICourse _cource;

        public AdminController(ICourse cource)
        {
            _cource = cource;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Courses()
        {
            return View();
        }
        public ActionResult Students()
        {
            return View();
        }
        public ActionResult Teachers()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(CourseModel model)
        {
            if (ModelState.IsValid)
            {
                var courceExists = _cource.CourseExists(model.Title);
                if (!courceExists)
                {
                    var course = new NewCourse()
                    {
                        Title = model.Title,
                        Price = model.Price
                    };
                    // добавляем пользователя в бд
                    _cource.AddCourse(course);

                    return RedirectToAction("Index", "Home");

                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
    }
}