using Application.Abstraction.Services;
using Application.Features.Queries.Post.GetAllPosts;
using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Post
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQueryRequest, GetAllPostsQueryResponse>
    {
        readonly IPostReadRepository _postsRepository;
        readonly ICategoryService _categoryService;
        public GetAllPostsQueryHandler(IPostReadRepository postsRepository, ICategoryService categoryService)
        {
            _postsRepository = postsRepository;
            _categoryService = categoryService;
        }

        public async Task<GetAllPostsQueryResponse> Handle(GetAllPostsQueryRequest request, CancellationToken cancellationToken)
        {

            var posts = _postsRepository.GetAll(false)
                .Include(p => p.BlogImages).ThenInclude(p=>p.BlogPostImageFile).Include(p=>p.BlogPostCategories).ThenInclude(p=>p.Category)
                .Select(p => new
                {
                    p.BlogPostCategories,
                    p.Header,
                    p.Id,
                    p.CreatedDate,
                    p.BlogImages,
                    p.Text,
                    p.Title
                }).ToList();

            return new ()
            {
                Posts = posts
            };
            
        }
    }
}
