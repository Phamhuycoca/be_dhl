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
    public class ImagePostService : IImagePostService
    {
        private readonly IImagePostRepo _repo;
        private readonly IMapper _mapper;
        public ImagePostService(IImagePostRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public bool Create(ImagePostDto dto)
        {
            return _repo.Add(_mapper.Map<ImagePost>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<ImagePostDto> getAll()
        {
            return _mapper.Map<List<ImagePostDto>>(_repo.GetAll());
        }

        public ImagePostDto GetById(int id)
        {
            return _mapper.Map<ImagePostDto>(_repo.GetById(id));
        }

        public bool Update(ImagePostDto dto)
        {
            return _repo.Update(_mapper.Map<ImagePost>(dto));
        }
    }
}
