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
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCource()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCource(CourceModel model)
        {
            if (ModelState.IsValid)
            {
                var courceExists = _cource.CourseExists(model.Title);
                if (!courceExists)
                {
                    var cource = new NewCourse()
                    {
                        Title = model.Title,
                        Price = model.Price
                    };
                    // добавляем пользователя в бд
                    _cource.AddCourse(cource);

                    return RedirectToAction("Index", "Home");

                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
    }
}