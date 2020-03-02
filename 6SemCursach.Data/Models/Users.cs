
namespace _6SemCursach.Data.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Teachers Teacher { get; set; }
        public Students Student { get; set; }

        public int IdRole { get; set; }
        public Roles Role { get; set; }
    }
}
