using Microsoft.AspNetCore.Http;
using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.IServices
{
    public interface IPostService
    {
        List<PostDto> getAll(int id);
        List<Post_User_Dto> getAll();
        List<PostDto> getAlls();
        Post_User_Dto GetById(int id);
        bool Create(PostDto dto, IList<IFormFile> listFile, string url);
        bool Update(PostDto dto, List<ImagePostDto> ImagePostDtoList, IList<IFormFile> listFile, string url);
        bool Delete(int id);
        PostDto getById(int id);
    }
}
