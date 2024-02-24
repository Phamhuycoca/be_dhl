using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Modules
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<INewsRepo, NewsRepo>();
            services.AddScoped<IImageNewsRepo, ImageNewsRepo>();
            services.AddScoped<INewsContentRepo, NewsContentRepo>();
            services.AddScoped<IPostRepo, PostRepo>();
            services.AddScoped<IImagePostRepo, ImagePosRepo>();
            services.AddScoped<INotiRepo, NotiRepo>();
            services.AddScoped<ICommentNewsRepo, CommentNewsRepo>();
            services.AddScoped<ICommentPostRepo, CommentPostRepo>();
            return services;
        }    
    }
}
