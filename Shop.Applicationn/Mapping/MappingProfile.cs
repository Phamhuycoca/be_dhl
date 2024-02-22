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
            CreateMap<Department,DepartmentDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<News,NewsDto>().ReverseMap();
            CreateMap<NewsContent, NewsContentDto>().ReverseMap();
            CreateMap<ImageNews, ImageNewsDto>().ReverseMap();
            CreateMap<ImagePost, ImagePostDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Notification, NotificationDto>().ReverseMap();
        }
    }
}
