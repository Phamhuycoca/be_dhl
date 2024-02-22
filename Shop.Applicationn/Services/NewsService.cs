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
        public NewsService(IMapper mapper, INewsRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public bool Create(NewsDto dto)
        {
            return _repo.Add(_mapper.Map<News>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<NewsDto> getAll()
        {
            return _mapper.Map<List<NewsDto>>(_repo.GetAll().OrderByDescending(x=>x.NewsId));
        }

        public List<NewsDto> getAll(int id)
        {
            return _mapper.Map<List<NewsDto>>(_repo.GetAll().Where(x=>x.DepartmentId==id));
        }

        public NewsDto GetById(int id)
        {
            return _mapper.Map<NewsDto>(_repo.GetById(id));
        }

        public bool Update(NewsDto dto)
        {
            return _repo.Update(_mapper.Map<News>(dto));
        }
    }
}
