using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Applicationn.IServices
{
    public interface IDepartmentService
    {
        List<DepartmentDto> getAll();
        DepartmentDto GetById(int id);
        bool Create(DepartmentDto dto);
        bool Update(DepartmentDto dto);
        bool Delete(int id);
    }
}
