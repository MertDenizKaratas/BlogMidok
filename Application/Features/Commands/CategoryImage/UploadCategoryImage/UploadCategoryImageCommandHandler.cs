using Application.Features.Commands.PostImage.UploadImageFile;
using Application.Repositories.PostImage;
using Application.Repositories;
using ETicaretAPI.Application.Abstractions.Storage;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Repositories.CategoryImage;

namespace Application.Features.Commands.CategoryImage.UploadCategoryImage
{
    public class UploadCategoryImageCommandHandler : IRequestHandler<UploadCategoryImageCommandRequest, UploadCategoryImageCommandResponse>
    {
        readonly IStorageService _storageService;
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly IConfiguration configuration;
        readonly ICategoryImageWriteRepository _categoryImageWriteRepository;
        public UploadCategoryImageCommandHandler(ICategoryReadRepository categoryReadRepository, IStorageService storageService, IConfiguration configuration, ICategoryImageWriteRepository categoryImageWriteRepository)
        {

            _categoryReadRepository = categoryReadRepository;
            _storageService = storageService;
            this.configuration = configuration;
            _categoryImageWriteRepository = categoryImageWriteRepository;
        }
        public async Task<UploadCategoryImageCommandResponse> Handle(UploadCategoryImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

            Domain.Entities.Category category = await _categoryReadRepository.GetByIdAsync(request.Id);

            await _categoryImageWriteRepository.AddRangeAsyncDifferentForCategory(result.Select(r => new CategoryImageFile
            {
                FileName = r.fileName,
                Path = Path.Combine(configuration.GetSection("BaseStorageUrl").Value.ToString(), r.pathOrContainerName),
                Storage = _storageService.StorageName
            }).ToList(), request.Id);

            await _categoryImageWriteRepository.SaveAsync();



            return new();
        }
    }
}
