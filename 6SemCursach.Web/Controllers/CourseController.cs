using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using _6SemCursach.BusinessLogic.Models;
using _6SemCursach.BusinessLogic.Services;
using _6SemCursach.Web.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _6SemCursach.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly IConverter _converter; 
        private readonly ICourse _course;
        private readonly IWebHostEnvironment _appEnvironment;
       

        public CourseController(
            ICourse course,
            IWebHostEnvironment environment,
            IConverter converter)
        {
            _course = course;
            _appEnvironment = environment;
            _converter = converter;
        }
        public IActionResult ListCourses()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;

            return role switch
            {
                "Admin" => View("ListCoursesForAdmin", _course.GetAllCourses()),
                "Student" => View("ListCoursesForStudent",
                    _course.GetListCourseForStudent(User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType)
                        .Value)),
                "Teacher" => View("ListCoursesForTeacher", _course.GetAllCourses()),
                _ => null
            };
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
                var courseExists = _course.CourseExists(model.Title);
                if (!courseExists)
                {
                    var course = new NewCourse()
                    {
                        Title = model.Title,
                        Price = model.Price
                    };
                    // добавляем курс в бд
                    _course.AddCourse(course);

                    return RedirectToAction("Index", "Home");

                }
                else
                    ModelState.AddModelError("", "косяк");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCoursesFromFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCoursesFromFile(IFormFile uploadedFile)
        {
            var courses = new List<CourseModel>();
            var formatter = new XmlSerializer(courses.GetType());
           
            using (var streamReader = new StreamReader(uploadedFile.OpenReadStream()))
            {
                courses = (List<CourseModel>)formatter.Deserialize(streamReader);
            }

            foreach (var modelCourse in courses)
            {
                var courceExists = _course.CourseExists(modelCourse.Title);
                if (!courceExists)
                {
                    var course = new NewCourse()
                    {
                        Title = modelCourse.Title,
                        Price = modelCourse.Price
                    };
                    // добавляем пользователя в бд
                    _course.AddCourse(course);
                }
            }
            return View();
        }

        public IActionResult DownloadCoursesInFile()
        {
            var str = _appEnvironment.ContentRootPath;
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files/courses.xml");
            var courses = _course.GetAllCourses();
            var formatter = new XmlSerializer(courses.GetType());

            FileStream fs = new FileStream(file_path, FileMode.OpenOrCreate);
            formatter.Serialize(fs, courses);

            string file_type = "application/xml";
            string file_name = "courses.xml";


            return PhysicalFile(file_path, file_type, file_name);
        }

        public IActionResult DownloadCoursesInPdfFile()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = DinkToPdf.Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);

            return File(file, "application/pdf");
        }

        private string GetHTMLString()
        {
            var courses = _course.GetAllCourses();

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Title</th>
                                        <th>Price</th>                                     
                                    </tr>");

            foreach (var course in courses)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                  </tr>", course.Title, course.Price);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}