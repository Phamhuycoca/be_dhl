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
    public class UserService:IUserService
    {
        private readonly IUserRepo _categoryRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public List<UserDto> GetAll()
        {
            return _mapper.Map<List<UserDto>>(_categoryRepo.GetAll());
        }
        public UserDto Get(int id)
        {
            return _mapper.Map<UserDto>(_categoryRepo.Get(id));
        }
        public bool Add(UserDto categoryDto)
        {
            return _categoryRepo.Add(_mapper.Map<User>(categoryDto));
        }
        public bool Update(UserDto categoryDto)
        {
            return _categoryRepo.Update(_mapper.Map<User>(categoryDto));
        }
        public bool Delete(int id)
        {
            return _categoryRepo.Delete(id);
        }
    }
}
