using Data;
using Models.ReplyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReplyService
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        public void AddReply(ReplyCreateModel replyToCreate)
        {
            var entity = new Reply()
            {
                UserId = _userId,
                Text = replyToCreate.Text,
                CommentId = replyToCreate.CommentId,
                PostId = _ctx.Comments.Single(e => e.CommentId == replyToCreate.CommentId).PostId
            };
            _ctx.Replies.Add(entity);
            _ctx.SaveChanges();
        }
        public IEnumerable<ReplyListItem> GetRepliesByComment(int commentId)
        {
            var returnList = _ctx.Replies.Where(e => e.CommentId == commentId).Select(e => new ReplyListItem
            {
                ReplyCommentText = e.ReplyComment.Text,
                Text = e.Text
            }).ToList();
            return returnList;
        }
    }

}
