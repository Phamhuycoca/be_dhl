using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.IServices
{
    public interface IImagePostService
    {
        List<ImagePostDto> getAll();
        ImagePostDto GetById(int id);
        bool Create(ImagePostDto dto);
        bool Update(ImagePostDto dto);
        bool Delete(int id);
    }
}
