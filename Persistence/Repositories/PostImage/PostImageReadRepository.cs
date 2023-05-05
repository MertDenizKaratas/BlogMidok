using Application.Repositories.PostImage;
using Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.PostImage
{
    public class PostImageReadRepository : ReadRepository<BlogPostImageFıle>, IPostImageReadRepository
    {
        public PostImageReadRepository(BlogMidokDBContext context) : base(context)
        {
        }
    }
}
