
namespace _6SemCursach.Data.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }

        public int UserFK { get; set; }
        public User User { get; set; }

        public Course Course { get; set; }
    }
}
