using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TopoServices.Contracts.V1;
using TopoServices.Contracts.V1.Requests;
using TopoServices.Domain;
using TopoServices.Services;

namespace TopoServices.Controllers.V1
{
    public class PostsController : Controller
    {
        readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [Route(APIRoutes.Posts.GetAll)]
        public IActionResult GetAllPosts()
        {
            return Ok(_postService.GetAllPosts());
        }

        [HttpGet]
        [Route(APIRoutes.Posts.GetPostById)]
        public IActionResult GetPostById(Guid postId)
        {
            var post = _postService.GetPostById(postId);
            if (post != null) return Ok(post);
            else return NotFound();
        }

        [HttpPost]
        [Route(APIRoutes.Posts.CreatePost)]
        public IActionResult CreatePost([FromBody] PostRequest request)
        {
            var post = new PostEntity(Guid.NewGuid(), request.Title);
            _postService.CreatePost(post);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + APIRoutes.Posts.GetPostById.Replace("{postId}", post.PostId.ToString());
            return Created(locationUrl, post);
        }

        [HttpPut]
        [Route(APIRoutes.Posts.UpdatePost)]
        public IActionResult UpdatePost([FromBody] UpdateRequest request)
        {
            var postEntity = new PostEntity { PostId = request.PostId, Title = request.Title };
            var updated = _postService.UpdatePost(postEntity);
            if (updated) return Ok(postEntity);
            else return NotFound();
        }

        [HttpDelete]
        [Route(APIRoutes.Posts.DeletePost)]
        public IActionResult DeletPost(Guid postId)
        {
            var deleted = _postService.DeletePost(postId);
            if (deleted) return NoContent();
            else return NotFound();
        }
    }
}
