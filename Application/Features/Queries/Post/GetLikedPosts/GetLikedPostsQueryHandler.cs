using Application.Features.Queries.Post.GetLikedPosts;
using Application.Repositories;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
    public class GetLikedPostsQueryHandler : IRequestHandler<GetLikedPostsQueryRequest, GetLikedPostsQueryResponse>
    {
        readonly IPostReadRepository _postsRepository;
        readonly UserManager<AppUser> _userManager;
        readonly IHttpContextAccessor _contextAccessor;
        public GetLikedPostsQueryHandler(IPostReadRepository postsRepository, UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _postsRepository = postsRepository;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<GetLikedPostsQueryResponse> Handle(GetLikedPostsQueryRequest request, CancellationToken cancellationToken)
        {
            var username = _contextAccessor?.HttpContext?.User?.Identity?.Name;


                var user = await _userManager.FindByNameAsync(username);
                var posts = await _postsRepository.Trying(user.Id);
            return new GetLikedPostsQueryResponse()
            {
                Posts = posts,
            };

            
        }
    }
}
