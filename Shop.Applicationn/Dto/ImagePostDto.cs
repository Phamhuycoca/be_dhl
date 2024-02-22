using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class ImagePostDto
    {
        public int ImagePostId { get; set; }
        public string? ImagePostUrl { get; set; }
        public string? UrlApi { get; set; }
        public int PostId { get; set; } 
    }
}
