using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class Post_User_Dto
    {
        public int PostId { get; set; }
        public string? PostTittle { get; set; }
        public string? PostContent { get; set; }
        public DateTime? PostDate { get; set; }
        public bool? IsStatus { get; set; }
        public int UserId { get; set; }
        public string? FullName { get; set; }
    }
}
