using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _6SemCursach.Web.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
        //public List<SelectListItem> Roles { get; } = new List<SelectListItem>
        //{
        //    new SelectListItem { Value = "Teacher", Text = "Teacher" },
        //    new SelectListItem { Value = "Student", Text = "Student" }
        //};
    }
}
