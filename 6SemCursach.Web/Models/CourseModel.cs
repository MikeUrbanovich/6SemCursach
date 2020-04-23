
using System.ComponentModel.DataAnnotations;

namespace _6SemCursach.Web.Models
{
    public class CourseModel
    {
        public CourseModel()
        { }
        [Required(ErrorMessage = "Не указано Название")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Не указана Цена")]
        public double Price { get; set; }
    }
}
