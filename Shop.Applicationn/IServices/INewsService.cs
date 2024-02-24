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
        List<NewsUer> getAll();
        NewsUer GetById(int id);
        bool Create(NewsDto dto);
        bool Update(NewsDto dto);
        bool Delete(int id);
        List<NewsUer> getAll(int id);

    }
}
