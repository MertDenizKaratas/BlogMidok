using Application.Features.Commands.CategoryImage.UploadCategoryImage;
using Application.Repositories.PostLike;
using Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.PostLike.LikePost
{
    public class LikePostCommandHandler : IRequestHandler<LikePostCommandRequest, LikePostCommandResponse>
    {
        readonly IPostLikeWriteRepository _postLikeWriteRepository;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        public LikePostCommandHandler(IPostLikeWriteRepository postLikeWriteRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _postLikeWriteRepository = postLikeWriteRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<LikePostCommandResponse> Handle(LikePostCommandRequest request, CancellationToken cancellationToken)
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Identity.Name;
            if(username != null)
            {
               var user = await _userManager.FindByNameAsync(username);
                var userId = user.Id;
                if(user != null)
                {
                    var postLike = new Domain.Entities.PostLike { PostId = request.Id, UserId = userId };
                    await _postLikeWriteRepository.AddAsync(postLike);
                    await _postLikeWriteRepository.SaveAsync();
                }
            }


            return new();
        }
    }
}
