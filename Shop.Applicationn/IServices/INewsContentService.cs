using Microsoft.AspNetCore.Http;
using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.IServices
{
    public interface INewsContentService
    {
        List<NewsContentDto> getAll(int id);
        NewsContentDto GetById(int id);
        bool Create(NewsContentDto dto, IList<IFormFile> listFile, string url);
        bool Update(NewsContentDto dto, List<ImageNewsDto> ImageContentList, IList<IFormFile> listFile, string url);
        bool Delete(int id);
    }
}
