using Application.Features.Commands.Category.CreateCategory;
using Application.Features.Commands.CategoryImage.UploadCategoryImage;
using Application.Features.Commands.PostImage.UploadImageFile;
using Application.Features.Commands.Posts.CreatePost;
using Application.Features.Queries.BlogPostCategory.GetBlogsByCategory;
using Application.Features.Queries.Category.GetAllCategory;
using Application.Features.Queries.Post.GetAllPosts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogMidok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadCategoryImageCommandRequest UploadCategoryImageCommandRequest)
        {
            UploadCategoryImageCommandRequest.Files = Request.Form.Files;
            UploadCategoryImageCommandRequest.Id = Convert.ToInt32(Request.Form["id"]);
            UploadCategoryImageCommandResponse response = await _mediator.Send(UploadCategoryImageCommandRequest);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCategoriesQueryRequest getAllCategoriesQueryRequest)
        {
            GetAllCategoriesQueryResponse response = await _mediator.Send(getAllCategoriesQueryRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPostsByCategory([FromRoute] GetBlogsByCategoryQueryRequest getBlogsByCategoryQueryRequest)
        {
            GetBlogsByCategoryQueryResponse response = await _mediator.Send(getBlogsByCategoryQueryRequest);
            return Ok(response);
        }


    }
}
