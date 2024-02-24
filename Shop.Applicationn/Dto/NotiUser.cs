using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class NotiUser
    {
        public int NotificationId { get; set; }
        public int? PostId { get; set; }
        public int? NewsId { get; set; }
        public int? UserIdComment { get; set; }
        public int? UserId { get; set; }
        public int? Status { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
    }
}
