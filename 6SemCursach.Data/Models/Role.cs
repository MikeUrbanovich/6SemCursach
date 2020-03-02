using System;
using System.Collections.Generic;
using System.Text;

namespace _6SemCursach.Data.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Title { get; set; }
        public List<User> Users { get; set; } 
    }
    
}
