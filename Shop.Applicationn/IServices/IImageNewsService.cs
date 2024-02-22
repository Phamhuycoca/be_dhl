using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.IServices
{
    public interface IImageNewsService
    {
        List<ImageNewsDto> getAll();
        ImageNewsDto GetById(int id);
        bool Create(ImageNewsDto dto);
        bool Update(ImageNewsDto dto);
        bool Delete(int id);
    }
}
