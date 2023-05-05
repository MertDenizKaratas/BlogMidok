using Application.Repositories;
using Application.Repositories.PostImage;
using Domain.Entities;
using ETicaretAPI.Application.Abstractions.Storage;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.PostImage.UploadImageFile
{
    public class UploadPostImageCommandHandler : IRequestHandler<UploadPostImageCommandRequest, UploadPostImageCommandResponse>
    {
        readonly IStorageService _storageService;
        readonly IPostReadRepository _postReadRepository;
        readonly IPostImageWriteRepository _postImageWriteRepository;
        readonly IConfiguration configuration;
        public UploadPostImageCommandHandler(IPostImageWriteRepository postImageWriteRepository, IPostReadRepository postReadRepository, IStorageService storageService, IConfiguration configuration)
        {
            _postImageWriteRepository = postImageWriteRepository;
            _postReadRepository = postReadRepository;
            _storageService = storageService;
            this.configuration = configuration;
        }

        public async Task<UploadPostImageCommandResponse> Handle(UploadPostImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

            BlogPost blogpost = await _postReadRepository.GetByIdAsync(request.Id);

            
            await _postImageWriteRepository.AddRangeAsyncDifferentForBlogPost(result.Select(r => new BlogPostImageFıle
            {
                FileName = r.fileName,
                Path = Path.Combine(configuration.GetSection("BaseStorageUrl").Value.ToString(), r.pathOrContainerName),
                Storage = _storageService.StorageName
            }).ToList(),request.Id);

            await _postImageWriteRepository.SaveAsync();



            return new();


        }
    }
}
