using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class NewsUer
    {
        public int NewsId { get; set; }
        public string? TieuDeTinTuc { get; set; }
        public DateTime? NgayDang { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string? FullName { get; set;}
    }
}
