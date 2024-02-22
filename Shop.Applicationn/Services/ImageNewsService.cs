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
    public class ImageNewsService : IImageNewsService
    {
        private readonly IImageNewsRepo _repo;
        private readonly IMapper _mapper;
        public ImageNewsService(IImageNewsRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public bool Create(ImageNewsDto dto)
        {
            return _repo.Add(_mapper.Map<ImageNews>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<ImageNewsDto> getAll()
        {
            return _mapper.Map<List<ImageNewsDto>>(_repo.GetAll());
        }

        public ImageNewsDto GetById(int id)
        {
            return _mapper.Map<ImageNewsDto>(_repo.GetById(id));
        }

        public bool Update(ImageNewsDto dto)
        {
            return _repo.Update(_mapper.Map<ImageNews>(dto));
        }
    }
}
