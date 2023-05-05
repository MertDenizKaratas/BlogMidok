﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.PostLike.LikePost
{
    public class LikePostCommandRequest : IRequest<LikePostCommandResponse>
    {
        public int Id { get; set; }
    }
}
