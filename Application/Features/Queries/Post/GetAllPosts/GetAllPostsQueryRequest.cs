﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Post.GetAllPosts
{
    public class GetAllPostsQueryRequest : IRequest<GetAllPostsQueryResponse>
    {
    }
}
