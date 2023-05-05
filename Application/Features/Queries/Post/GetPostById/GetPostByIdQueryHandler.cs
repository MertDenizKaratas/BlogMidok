using Application.Features.Queries.Post.GetAllPosts;
using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Post.GetPostById
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQueryRequest, GetPostByIdQueryResponse>
    {
        readonly IPostReadRepository _postReadRepository;
        public GetPostByIdQueryHandler(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;
        }

        public async Task<GetPostByIdQueryResponse> Handle(GetPostByIdQueryRequest request, CancellationToken cancellationToken)
        {
            BlogPost post = await _postReadRepository.GetByIdAsyncDifferent(request.Id, false);
            return new()
            {
               Post = post
            };
        }
    }
}
