using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.IServices
{
    public interface ICommentNewsService
    {
        List<CommentNewsUser> getAll();
        List<CommentNewsUser> getByIdUser(int id);
        CommentNewsDto GetById(int id);
        bool Create(CommentNewsDto dto);
        bool Update(CommentNewsDto dto);
        bool Delete(int id);
    }
}
