using Application.Features.Commands.PostImage.UploadImageFile;
using Application.Features.Commands.PostLike.LikePost;
using Application.Features.Commands.PostLike.UnlikePost;
using Application.Features.Commands.Posts.CreatePost;
using Application.Features.Queries.AppUser.GetCurrentUser;
using Application.Features.Queries.Post.GetAllPosts;
using Application.Features.Queries.Post.GetLikedPosts;
using Application.Features.Queries.Post.GetPostById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogMidok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class BlogController : ControllerBase
    {
        readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePostCommandRequest createPostCommandRequest)
        {
            CreatePostCommandResponse response = await _mediator.Send(createPostCommandRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery]UploadPostImageCommandRequest UploadPostImageCommandRequest)
        {
            UploadPostImageCommandRequest.Files = Request.Form.Files;
            UploadPostImageCommandRequest.Id = Convert.ToInt32(Request.Form["id"]);
            UploadPostImageCommandResponse response = await _mediator.Send(UploadPostImageCommandRequest);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPostsQueryRequest getAllPostsQueryRequest)
        {
            GetAllPostsQueryResponse response = await _mediator.Send(getAllPostsQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetPostByIdQueryRequest getPostByIdQueryRequest)
        {
            GetPostByIdQueryResponse response = await _mediator.Send(getPostByIdQueryRequest);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCurrentUser([FromRoute] GetCurrentUserQueryRequest getCurrentUserQueryRequest)
        {
            GetCurrentUserQueryResponse response = await _mediator.Send(getCurrentUserQueryRequest);
            return Ok(response);
        }
        [HttpPost("[action]/{Id}")]
        public async Task<IActionResult> LikePost([FromRoute] LikePostCommandRequest likePostCommandRequest)
        {
            LikePostCommandResponse response = await _mediator.Send(likePostCommandRequest);
            return Ok(response);
        }
        [HttpPost("[action]/{Id}")]
        public async Task<IActionResult> UnlikePost([FromRoute] UnlikePostCommandRequest unlikePostCommandRequest)
        {
            UnlikePostCommandResponse response = await _mediator.Send(unlikePostCommandRequest);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> UnlikePost([FromQuery] GetLikedPostsQueryRequest getLikedPostsQueryRequest)
        {
            GetLikedPostsQueryResponse response = await _mediator.Send(getLikedPostsQueryRequest);
            return Ok(response);
        }
    }
}
