using Application.Repositories.PostLike;
using ETicaretAPI.Persistence.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.PostLike
{
    public class PostLikeWriteRepository : WriteRepository<Domain.Entities.PostLike>, IPostLikeWriteRepository
    {
        public PostLikeWriteRepository(BlogMidokDBContext context) : base(context)
        {
        }
    }
}
