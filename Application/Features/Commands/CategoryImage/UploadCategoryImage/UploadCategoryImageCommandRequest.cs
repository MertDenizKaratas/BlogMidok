using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.CategoryImage.UploadCategoryImage
{
    public class UploadCategoryImageCommandRequest : IRequest<UploadCategoryImageCommandResponse>
    {
        public int Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
