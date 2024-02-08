using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto Get(int id);
        bool Add(ProductDto categoryDto);
        bool Update(ProductDto categoryDto);
        bool Delete(int id);
    }
}
