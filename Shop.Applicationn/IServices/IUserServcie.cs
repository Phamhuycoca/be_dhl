using Microsoft.AspNetCore.Http;
using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.IServices
{
    public interface IUserServcie
    {
        List<UserDto> getAll();
        UserDto GetById(int id);
        bool Create(UserDto dto);
        bool ChangePassword(UserDto dto);
        bool Update(UserDto dto, IFormFile file,string url);
        bool Delete(int id);
    }
}
