using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Avatar {  get; set; }
        public bool Gender { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<News>? News { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Notification>? notifications { get; set; }

    }
}
