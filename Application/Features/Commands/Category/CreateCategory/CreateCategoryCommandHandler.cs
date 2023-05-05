using Application.Features.Commands.Posts.CreatePost;
using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly ICategoryReadRepository _categoryReadRepository;
        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }
        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryWriteRepository.AddAsync(new()
            {
                Description=request.Description,
                Name=request.Name
                
            });
            await _categoryWriteRepository.SaveAsync();

            return new CreateCategoryCommandResponse()
            {
                Id = _categoryReadRepository.GetSingleAsync(p => p.Description == request.Description).Result.Id

            };

        }
    }
}
