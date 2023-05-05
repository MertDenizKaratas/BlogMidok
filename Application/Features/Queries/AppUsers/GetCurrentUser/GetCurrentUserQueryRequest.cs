using Application.Features.Queries.Category.GetAllCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.AppUser.GetCurrentUser
{
    public class GetCurrentUserQueryRequest : IRequest<GetCurrentUserQueryResponse>
    {
    }
}
