using Application.Features.Queries.Post.GetAllPosts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoriesQueryRequest : IRequest<GetAllCategoriesQueryResponse>
    {
    }
}
