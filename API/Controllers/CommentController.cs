using Data;
using Microsoft.AspNet.Identity;
using Models.CommentModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }
        [HttpPost]
        //[Route(Name ="AddComment")]
        public IHttpActionResult Post(CommentCreateModel commentToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCommentService();
            service.AddComment(commentToCreate);
            return Ok();
        }
        [HttpGet]
        //[Route(Name ="GetPostComments")]
        public IHttpActionResult Get(int postId)
        {
            var service = CreateCommentService();
            var comments = service.GetCommentsByPost(postId);
            return Ok(comments);
        }
        [HttpPut]
        //[Route(Name ="UpdateComment")]
        public IHttpActionResult Put(CommentUpdateModel commentToUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCommentService();
            service.UpdateComment(commentToUpdate);
            return Ok();
        }
        [HttpDelete]
        //[Route(Name ="RemoveComment")]
        public IHttpActionResult Delete(CommentDeleteModel commentToDelete)
        {
            var service = CreateCommentService();
            service.RemoveComent(commentToDelete);
            return Ok();
        }
    }
}
