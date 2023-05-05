using Application.Features.Commands.PostLike.LikePost;
using Application.Repositories.PostLike;
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

namespace Application.Features.Commands.PostLike.UnlikePost
{
    public class UnlikePostCommandHandler : IRequestHandler<UnlikePostCommandRequest, UnlikePostCommandResponse>
    {
        readonly IPostLikeReadRepository _postLikeReadRepository;
        readonly IPostLikeWriteRepository _postLikeWriteRepository;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        public UnlikePostCommandHandler(IPostLikeReadRepository postLikeReadRepository, IPostLikeWriteRepository postLikeWriteRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _postLikeReadRepository = postLikeReadRepository;
            _postLikeWriteRepository = postLikeWriteRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public async Task<UnlikePostCommandResponse> Handle(UnlikePostCommandRequest request, CancellationToken cancellationToken)
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Identity.Name;
            if (username != null)
            {
                var user = await _userManager.FindByNameAsync(username);
                var userId = user.Id;
                if (user != null)
                {
                    var postLike = await _postLikeReadRepository.GetWhere(p => p.UserId == userId).FirstOrDefaultAsync(p => p.PostId == request.Id);
                    if (postLike == null)
                    {
                        throw new NotFoundUserException();
                    }

                    _postLikeWriteRepository.Remove(postLike);
                    await _postLikeWriteRepository.SaveAsync();

                }
            }

            return new();
        }
    }
}
