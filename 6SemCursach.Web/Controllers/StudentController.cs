using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _6SemCursach.BusinessLogic.Services;
using _6SemCursach.Data.Models;
using _6SemCursach.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace _6SemCursach.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUser _user;
        private readonly ICourse _course;
        private readonly IStudent _student;

        public StudentController
        (
            IUser service,
            ICourse course,
            IStudent student)
        {
            _user = service;
            _course = course;
            _student = student;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BuyCourse (Course course)
        {
            _course.BuyCourse(course, User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value);
            return View(course);
        }

        public IActionResult Home()
        {
            var currentlyStudent = _student
                .GetStudent(
                    User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value
                    );
            return View(currentlyStudent);
        }

        public IActionResult CourseForCurrentlyStudent()
        {
            return View(_course.GetCourseForCurrentlyStudent(User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value));
        }
    }
}