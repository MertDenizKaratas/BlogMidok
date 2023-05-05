using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Posts.CreatePost
{
    public class CreatePostCommandRequest : IRequest<CreatePostCommandResponse>
    {
        public string? Title { get; set; }
        public string? Header { get; set; }
        public string? Text { get; set; }
        public int[] SelectCategory { get; set; }

    }
}
