using AutoMapper;
using Microsoft.AspNetCore.Http;
using Shop.Applicationn.Dto;
using Shop.Applicationn.IServices;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTap.Application.Helper;

namespace Shop.Applicationn.Services
{
    public class UserService : IUserServcie
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, IUserRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public bool ChangePassword(UserDto dto)
        {
            return _repo.Update(_mapper.Map<User>(dto));
        }

        public bool Create(UserDto dto)
        {
            return _repo.Add(_mapper.Map<User>(dto));
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<UserDto> getAll()
        {
            return _mapper.Map<List<UserDto>>(_repo.GetAll());
        }

        public UserDto GetById(int id)
        {
            return _mapper.Map<UserDto>(_repo.GetById(id));
        }

        public bool Update(UserDto dto, IFormFile file, string url)
        {
            try
            {
                if (file != null)
                {
                    string[] path = dto.Avatar.Split(url);
                    if (!String.IsNullOrEmpty(path[1]))
                    {
                        ServiceImage.deleteImage(path[1]);
                    }
                    dto.Avatar = url + ServiceImage.createImage(file);
                }
                _repo.Update(_mapper.Map<User>(dto));
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            //return _repo.Update(_mapper.Map<User>(dto));
        }
    }
}
