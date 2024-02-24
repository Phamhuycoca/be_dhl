using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string? PostTittle {  get; set; }
        public string? PostContent { get; set; }
        public DateTime? PostDate { get; set; }
        public bool? IsStatus { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<ImagePost>? ImagePosts { get; set; }
        public ICollection<Notification>? notifications { get; set; }
        public ICollection<CommentPost>? CommentPosts { get; set; }

    }
}
