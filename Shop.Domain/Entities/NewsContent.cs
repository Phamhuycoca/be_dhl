using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class NewsContent
    {
        public int NewsContentId { get; set; }
        public string? Content {  get; set; }
        public int NewsId { get; set; }
        public News? news { get; set; }
        public ICollection<ImageNews>? imagenews { get; set; }
    }
}
