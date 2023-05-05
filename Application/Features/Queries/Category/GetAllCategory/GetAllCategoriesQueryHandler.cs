using Application.Features.Queries.Post.GetAllPosts;
using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }
        public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryReadRepository.GetAll(false)
                .Include(p => p.CategoryImages).ThenInclude(p => p.CategoryImageFiles)
                .Select(p => new
                {
                    p.CategoryImages,
                    p.BlogPostCategories,
                    p.Id,
                    p.CreatedDate,
                    p.Name,
                    p.Description
                }).ToList();

            return new()
            {
                Categories = categories
            };
        }
    }
}
