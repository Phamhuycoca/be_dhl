using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Notification
    {
        public int NotificationId {  get; set; }
        public int? PostId { get; set; }
        public int? NewsId { get; set; }
        public int? UserIdComment { get; set; }
        public int? UserId{ get; set; }
        public int? Status { get; set; }
        public Post? post { get; set; }
        public News? News { get; set; }
        public User? User { get; set; }
    }
}
