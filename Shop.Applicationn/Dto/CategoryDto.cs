using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class CategoryDto
    {
        public int? CategoryId { get; set; }
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Tên loại sản phẩm tối thiểu 5 kí tự")]
        public string CategoryName { get; set; }
    }

}
