
namespace _6SemCursach.Data.Models
{
    public class Teachers
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }

        public int IDUser { get; set; }
        public Users User { get; set; }

        public Courses Course { get; set; }
    }
}
