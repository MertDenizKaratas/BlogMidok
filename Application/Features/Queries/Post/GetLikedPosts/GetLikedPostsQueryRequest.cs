using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Post.GetLikedPosts
{
    public class GetLikedPostsQueryRequest : IRequest<GetLikedPostsQueryResponse>
    {
    }
}
