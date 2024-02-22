using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class ImageNewsDto
    {
        public int ImageNewsId { get; set; }
        public string? ImageNewsUrl { get; set; }
        public string? UrlApi { get; set; }
        public int NewsContentId { get; set; }
    }
}
