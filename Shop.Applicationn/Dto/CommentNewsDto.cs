using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class CommentNewsDto
    {
        public int CommentNewsId { get; set; }
        public int? UserId { get; set; }
        public int? NewsId { get; set; }
        public string? CommentContent { get; set; }
        public DateTime? CreateComment { get; set; }
    }
}
