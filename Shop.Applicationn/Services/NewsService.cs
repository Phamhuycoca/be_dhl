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
    public class NewsService : INewsService
    {
        private readonly INewsRepo _repo;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;
        public NewsService(IMapper mapper, INewsRepo repo,IUserRepo userRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _userRepo = userRepo;
        }
        public bool Create(NewsDto dto)
        {
            return _repo.Add(_mapper.Map<News>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<NewsUer> getAll()
        {
            var query = from news in _repo.GetAll().OrderByDescending(x => x.NewsId)
                        join
                       user in _userRepo.GetAll() on news.UserId equals user.UserId
                        select new NewsUer
                        {
                            UserId = news.UserId,
                            DepartmentId = news.DepartmentId,
                            FullName = user.FullName,
                            NewsId = news.NewsId,
                            NgayDang = news.NgayDang,
                            TieuDeTinTuc = news.TieuDeTinTuc
                        };
            return query.ToList();
            //    return _mapper.Map<List<NewsDto>>(_repo.GetAll().OrderByDescending(x=>x.NewsId));
        }

        public List<NewsUer> getAll(int id)
        {
            var query = from news in _repo.GetAll().Where(x => x.DepartmentId == id)
                        join
                       user in _userRepo.GetAll() on news.UserId equals user.UserId
                        select new NewsUer
                        {
                            UserId = news.UserId,
                            DepartmentId = news.DepartmentId,
                            FullName=user.FullName,
                            NewsId=news.NewsId,
                            NgayDang= news.NgayDang,
                            TieuDeTinTuc = news.TieuDeTinTuc
                        };
            return query.ToList();

            //return _mapper.Map<List<NewsDto>>(_repo.GetAll().Where(x=>x.DepartmentId==id));
        }

        public NewsUer GetById(int id)
        {
            var query = (from news in _repo.GetAll() join
                         user in _userRepo.GetAll() on news.UserId equals user.UserId where news.NewsId ==id
                         select new NewsUer
                         {
                             UserId = news.UserId,
                             DepartmentId = news.DepartmentId,
                             FullName = user.FullName,
                             NewsId = news.NewsId,
                             NgayDang = news.NgayDang,
                             TieuDeTinTuc = news.TieuDeTinTuc
                         })                        
                .SingleOrDefault();

            return query;
            //return _mapper.Map<NewsDto>(_repo.GetById(id));
        }

        public bool Update(NewsDto dto)
        {
            return _repo.Update(_mapper.Map<News>(dto));
        }
    }
}
