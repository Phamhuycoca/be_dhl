using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class CommentPostUser
    {
        public int CommentPostId { get; set; }
        public int UserId { get; set; }
        public int? PostId { get; set; }
        public string? CommentContent { get; set; }
        public DateTime? CreateComment { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }

    }
}
