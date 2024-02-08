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
    public class ProductService:IProductService
    {
        private readonly IProductRepo _categoryRepo;
        private readonly IMapper _mapper;
        public ProductService(IProductRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public List<ProductDto> GetAll()
        {
            return _mapper.Map<List<ProductDto>>(_categoryRepo.GetAll());
        }
        public ProductDto Get(int id)
        {
            return _mapper.Map<ProductDto>(_categoryRepo.Get(id));
        }
        public bool Add(ProductDto categoryDto)
        {
            return _categoryRepo.Add(_mapper.Map<Product>(categoryDto));
        }
        public bool Update(ProductDto categoryDto)
        {
            return _categoryRepo.Update(_mapper.Map<Product>(categoryDto));
        }
        public bool Delete(int id)
        {
            return _categoryRepo.Delete(id);
        }
    }
}
