using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class NewsContentDto
    {
        public int NewsContentId { get; set; }
        public string? Content { get; set; }
        public int NewsId { get; set; }
    }
}
