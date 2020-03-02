
namespace _6SemCursach.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Teacher Teacher { get; set; }
        public Student Student { get; set; }

        public int IdRole { get; set; }
        public Role Role { get; set; }
    }
}
