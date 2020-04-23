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
    public class TeacherController : Controller
    {
        private readonly IUser _user;
        private readonly ICourse _course;
        private readonly IStudent _student;

        public TeacherController
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

        public IActionResult AddCourse(Course course)
        {
            var courseModel = new CourseWithStudentsModel
            {
                Course = course,
                Students = _student.GetStudentsForCourse(course)
            };

            _course.AddCourseForTeacher(course, User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value);

            return View(courseModel);
        }

    }
}