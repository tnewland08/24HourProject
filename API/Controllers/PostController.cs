using Microsoft.AspNet.Identity;
using Models.PullModels;
using Services;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/posts")]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }
        [HttpPost]
        [Route("addpost")]
        public IHttpActionResult Post(PostCreateModel postToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePostService();
            service.CreatePost(postToCreate);
            return Ok();
        }
        [HttpGet]
        [Route("postlist")]
        public IHttpActionResult Get()
        {
            var service = CreatePostService();
            var posts = service.GetPosts();
            return Ok(posts);
        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Put(PostUpdateModel postToUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePostService();
            service.UpdatePost(postToUpdate);
            return Ok();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(PostDeleteModel postToDelete)
        {
            var service = CreatePostService();
            service.RemovePost(postToDelete);
            return Ok();
        }
    }
}
