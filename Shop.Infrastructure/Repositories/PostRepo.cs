using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class PostRepo : Repo<Post>, IPostRepo
    {
        public PostRepo(ShopDbContext context) : base(context)
        {
        }
    }
}
