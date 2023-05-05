using Application.Repositories.CategoryImage;
using Application.Repositories.PostImage;
using Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.CategoryImage
{
    public class CategoryImageReadRepository : ReadRepository<CategoryImageFile>, ICategoryImageReadRepository
    {
        public CategoryImageReadRepository(BlogMidokDBContext context) : base(context)
        {
        }
    }
}
