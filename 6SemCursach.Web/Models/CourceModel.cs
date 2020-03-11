﻿
using System.ComponentModel.DataAnnotations;

namespace _6SemCursach.Web.Models
{
    public class CourceModel
    {
        [Required(ErrorMessage = "Не указано Название")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Не указана Цена")]
        public decimal Price { get; set; }
    }
}
