using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.IServices
{
    public interface ICommentPostService
    {
        List<CommentPostUser> getAll();
        List<CommentPostUser> getListById(int id);
        CommentPostDto GetById(int id);
        bool Create(CommentPostDto dto);
        bool Update(CommentPostDto dto);
        bool Delete(int id);
    }
}
