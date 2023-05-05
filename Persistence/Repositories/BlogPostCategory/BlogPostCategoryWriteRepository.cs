using Application.Repositories;
using Application.Repositories.BlogPostCategory;
using Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.BlogPostCategory
{
    public class BlogPostCategoryWriteRepository : WriteRepository<BlogPostCategories>, IBlogPostCategoryWriteRepository
    {
        public BlogPostCategoryWriteRepository(BlogMidokDBContext context) : base(context)
        {
        }
    }
}
