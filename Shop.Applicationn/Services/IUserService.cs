using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto Get(int id);
        bool Add(UserDto categoryDto);
        bool Update(UserDto categoryDto);
        bool Delete(int id);
    }
}
