using Data;
using Microsoft.AspNet.Identity;
using Models.CommentModels;
using Models.ReplyModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/replies")]
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }
        [HttpPost]
        [Route("addreply")]
        public IHttpActionResult Post(ReplyCreateModel replyToCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReplyService();
            service.AddReply(replyToCreate);
            return Ok();
        }
        [HttpGet]
        [Route("{commentId:int}")]
        public IHttpActionResult Get(int commentId)
        {
            var service = CreateReplyService();
            var replies = service.GetRepliesByComment(commentId);
            return Ok(replies);
        }
    }
}
