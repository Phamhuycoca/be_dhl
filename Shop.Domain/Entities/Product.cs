using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public long Quantity { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int CategoryId { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }
        public virtual Category Category { get; set; }
    }
}
