using Application.Repositories.CategoryImage;
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
    public class CategoryImageWriteRepository : WriteRepository<CategoryImageFile>, ICategoryImageWriteRepository
    {
        public CategoryImageWriteRepository(BlogMidokDBContext context) : base(context)
        {
        }
    }
}
