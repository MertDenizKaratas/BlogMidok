using Application.Repositories;
using Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Post
{
    public class PostWriteRepository : WriteRepository<BlogPost>, IPostWriteRepository
    {
        public PostWriteRepository(BlogMidokDBContext context) : base(context)
        {
        }
    }
}
