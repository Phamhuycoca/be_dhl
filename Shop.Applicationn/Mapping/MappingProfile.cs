using AutoMapper;
using Shop.Applicationn.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
        }
    }
}
