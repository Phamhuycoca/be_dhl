using AutoMapper;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public class CommentNewsService : ICommentNewsService
    {
        private readonly ICommentNewsRepo _repo;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;

        public CommentNewsService(IMapper mapper, ICommentNewsRepo repo, IUserRepo userRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _userRepo = userRepo;
        }
        public bool Create(CommentNewsDto dto)
        {
            return _repo.Add(_mapper.Map<CommentNews>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<CommentNewsUser> getAll()
        {
            var query = from users in _userRepo.GetAll()
                        join
                       comments in _repo.GetAll().OrderByDescending(x => x.CommentNewsId)
                       on users.UserId equals comments.UserId
                        select new CommentNewsUser
                        {
                            UserId = users.UserId,
                            CommentContent = comments.CommentContent,
                            CommentNewsId = comments.CommentNewsId,
                            CreateComment = comments.CreateComment,
                            FullName = users.FullName,
                            NewsId = comments.NewsId,
                            Avatar = users.Avatar
                        };
            return query.ToList();
        }

        public CommentNewsDto GetById(int id)
        {
            return _mapper.Map<CommentNewsDto>(_repo.GetById(id));
        }

        public List<CommentNewsUser> getByIdUser(int id)
        {
            var query = from users in _userRepo.GetAll()
                        join
                       comments in _repo.GetAll().Where(x => x.NewsId == id).OrderByDescending(x => x.CommentNewsId)
                       on users.UserId equals comments.UserId
                        select new CommentNewsUser
                        {
                            UserId = users.UserId,
                            CommentContent = comments.CommentContent,
                            CommentNewsId = comments.CommentNewsId,
                            CreateComment = comments.CreateComment,
                            FullName = users.FullName,
                            NewsId = comments.NewsId,
                            Avatar = users.Avatar
                        };
            return query.ToList();
        }

        public bool Update(CommentNewsDto dto)
        {
            return _repo.Update(_mapper.Map<CommentNews>(dto));
        }
    }
}
