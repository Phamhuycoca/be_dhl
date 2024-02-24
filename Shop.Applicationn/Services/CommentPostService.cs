using AutoMapper;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public class CommentPostService : ICommentPostService
    {
        private readonly ICommentPostRepo _repo;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;
        public CommentPostService(IMapper mapper, ICommentPostRepo repo, IUserRepo userRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _userRepo = userRepo;
        }
        public bool Create(CommentPostDto dto)
        {
            return _repo.Add(_mapper.Map<CommentPost>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<CommentPostUser> getAll()
        {
            var query = from users in _userRepo.GetAll()
                        join
                       comments in _repo.GetAll().OrderByDescending(x => x.CommentPostId)
                       on users.UserId equals comments.UserId
                        select new CommentPostUser
                        {
                            UserId = users.UserId,
                            CommentContent=comments.CommentContent,
                            CommentPostId=comments.CommentPostId,
                            CreateComment=comments.CreateComment,
                            FullName= users.FullName,
                            PostId = comments.PostId,
                            Avatar = users.Avatar
                        };
            return query.ToList();
        }

        public CommentPostDto GetById(int id)
        {
            return _mapper.Map<CommentPostDto>(_repo.GetById(id));
        }

        public List<CommentPostUser> getListById(int id)
        {
            var query = from users in _userRepo.GetAll()
                        join
                       comments in _repo.GetAll().Where(x=>x.PostId==id).OrderByDescending(x => x.CommentPostId)
                       on users.UserId equals comments.UserId
                        select new CommentPostUser
                        {
                            UserId = users.UserId,
                            CommentContent = comments.CommentContent,
                            CommentPostId = comments.CommentPostId,
                            CreateComment = comments.CreateComment,
                            FullName = users.FullName,
                            PostId = comments.PostId,
                            Avatar = users.Avatar
                        };
            return query.ToList();
        }

        public bool Update(CommentPostDto dto)
        {
            return _repo.Update(_mapper.Map<CommentPost>(dto));
        }
    }
}
