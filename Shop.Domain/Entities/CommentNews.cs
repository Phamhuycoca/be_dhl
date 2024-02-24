using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class CommentNews
    {
        public int CommentNewsId { get; set; }
        public int? UserId { get; set; }
        public int? NewsId { get; set; }
        public string? CommentContent { get; set; }
        public DateTime? CreateComment {  get; set; }
        public User? User { get; set; }
        public News? News { get; set; }

    }
}
