using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        CategoryDto Get(int id);
        bool Add(CategoryDto categoryDto);
        bool Update(CategoryDto categoryDto);
        bool Delete(int id);
    }
}
