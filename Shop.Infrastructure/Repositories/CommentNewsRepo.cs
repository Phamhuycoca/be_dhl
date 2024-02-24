﻿using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class CommentNewsRepo : Repo<CommentNews>, ICommentNewsRepo
    {
        public CommentNewsRepo(ShopDbContext context) : base(context)
        {
        }
    }
}
