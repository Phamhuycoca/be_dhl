using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.IServices
{
    public interface INewsService
    {
        List<NewsDto> getAll();
        NewsDto GetById(int id);
        bool Create(NewsDto dto);
        bool Update(NewsDto dto);
        bool Delete(int id);
        List<NewsDto> getAll(int id);

    }
}
