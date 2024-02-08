using AutoMapper;
using Shop.Applicationn.Dto;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{

    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public List<CategoryDto> GetAll()
        {
            return _mapper.Map<List<CategoryDto>>(_categoryRepo.GetAll());
        }    
        public CategoryDto Get(int id)
        {
            return _mapper.Map<CategoryDto>(_categoryRepo.Get(id));
        }    
        public bool Add(CategoryDto categoryDto)
        {
            return _categoryRepo.Add(_mapper.Map<Category>(categoryDto));
        }
        public bool Update(CategoryDto categoryDto)
        {
            return _categoryRepo.Update(_mapper.Map<Category>(categoryDto));
        }
        public bool Delete(int id)
        {
            return _categoryRepo.Delete(id);
        }
    }
}
