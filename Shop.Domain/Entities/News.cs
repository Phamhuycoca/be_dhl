using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class News
    {
        public int NewsId { get; set; }
        public string? TieuDeTinTuc {  get; set; }
        public DateTime? NgayDang {  get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public User? User { get; set; }
        public Department? Department { get; set; }
        public ICollection<NewsContent>? newsContents { get; set; }
        public ICollection<Notification>? notifications { get; set; }
    }
}
