using Application.Features.Queries.Post.GetPostById;
using Application.Repositories.BlogPostCategory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.BlogPostCategory.GetBlogsByCategory
{
    public class GetBlogsByCategoryQueryHandler : IRequestHandler<GetBlogsByCategoryQueryRequest, GetBlogsByCategoryQueryResponse>
    {
        readonly IBlogPostCategoryReadRepository _blogPostCategoryReadRepository;
        public GetBlogsByCategoryQueryHandler(IBlogPostCategoryReadRepository blogPostCategoryReadRepository)
        {
            _blogPostCategoryReadRepository = blogPostCategoryReadRepository;
        }
        public async Task<GetBlogsByCategoryQueryResponse> Handle(GetBlogsByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var posts = await _blogPostCategoryReadRepository
                .GetWhere(p=>p.CategoryId==request.Id)
                .Include(p=>p.BlogPost)
                .Select(p=>p.BlogPost)
                .ToListAsync();
            return new GetBlogsByCategoryQueryResponse()
            {
                Posts = posts
            };
        }
    }
}
