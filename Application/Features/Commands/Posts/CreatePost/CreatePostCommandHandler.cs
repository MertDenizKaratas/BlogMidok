using Application.Repositories;
using Application.Repositories.BlogPostCategory;
using Domain.Entities;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Features.Commands.Posts.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
    {
        readonly IPostWriteRepository _PostWriteRepository;
        readonly IPostReadRepository _PostReadRepository;
        readonly IBlogPostCategoryWriteRepository _BlogPostCategoryWriteRepository;
        readonly ICategoryReadRepository _CategoryReadRepository;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        public CreatePostCommandHandler(IPostWriteRepository postWriteRepository, IPostReadRepository postReadRepository, IBlogPostCategoryWriteRepository blogPostCategoryWriteRepository, ICategoryReadRepository categoryReadRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _PostWriteRepository = postWriteRepository;
            _PostReadRepository = postReadRepository;
            _BlogPostCategoryWriteRepository = blogPostCategoryWriteRepository;
            _CategoryReadRepository = categoryReadRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (username != null)
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user != null)
                {
                    await _PostWriteRepository.AddAsync(new()
                    {
                        Title = request.Title,
                        Text = request.Text,
                        Header = request.Header,
                        User = user
            });
                    await _PostWriteRepository.SaveAsync();
                }
                else
                {
                    throw new NotFoundUserException();
                }
            }
            

            var post = await _PostReadRepository.GetSingleAsync(p => p.Text == request.Text);

            var selectedCategoryIds = request.SelectCategory;

            // Find the categories by their IDs
            var selectedCategories =  await _CategoryReadRepository.GetWhere
                (category => selectedCategoryIds.Contains(category.Id))
                .ToListAsync();

            foreach (var category in selectedCategories)
            {
                var blogpostcategory = new BlogPostCategories
                {
                    BlogPostId = post.Id,
                    CategoryId = category.Id
                };
                await _BlogPostCategoryWriteRepository.AddAsync(blogpostcategory);
            }
            await _BlogPostCategoryWriteRepository.SaveAsync();
            return new CreatePostCommandResponse()
            {
                Id = _PostReadRepository.GetSingleAsync(p => p.Text == request.Text).Result.Id
            };

        }

    }
}
