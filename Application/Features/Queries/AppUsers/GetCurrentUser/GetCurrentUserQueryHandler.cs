using Application.Abstraction.Services;
using Application.Features.Queries.Category.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.AppUser.GetCurrentUser
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQueryRequest, GetCurrentUserQueryResponse>
    {
        readonly ICategoryService _categoryService;
        public GetCurrentUserQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<GetCurrentUserQueryResponse> Handle(GetCurrentUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _categoryService.GetCurrentUser();

            return new GetCurrentUserQueryResponse()
            {
                User= user
            };
        }
    }
}
