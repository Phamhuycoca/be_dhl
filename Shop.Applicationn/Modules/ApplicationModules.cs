using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Shop.Applicationn.IServices;
using Shop.Applicationn.Mapping;
using Shop.Applicationn.Services;
using Shop.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Modules
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationModules(this IServiceCollection services)
        {
            services.AddInfrastructureModule();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IUserServcie, UserService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsContentService, NewsContentService>();
            services.AddScoped<IImageNewsService, ImageNewsService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IImagePostService, ImagePostService>();
            services.AddScoped<INotiService, NotiService>();
            return services;
        }    
    }
}
