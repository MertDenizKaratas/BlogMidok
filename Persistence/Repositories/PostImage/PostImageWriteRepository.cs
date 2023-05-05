using Application.Repositories.PostImage;
using Domain.Entities;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.PostImage
{
    public class PostImageWriteRepository : WriteRepository<BlogPostImageFıle>, IPostImageWriteRepository
    {
        public PostImageWriteRepository(BlogMidokDBContext context) : base(context)
        {
        }

    }
}
