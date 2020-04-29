using Data;
using Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        public void AddComment(CommentCreateModel commentToCreate)
        {
            var entity = new Comment()
            {
                UserId = _userId,
                Text = commentToCreate.Text,
                PostId = commentToCreate.PostId
            };
            _ctx.Comments.Add(entity);
            _ctx.SaveChanges();
        }
        public IEnumerable<CommentListItem> GetCommentsByPost(int postId)
        {
            var returnList = _ctx.Comments.Where(e => e.PostId == postId).Select(e => new CommentListItem
            {
                CommentPostText = e.CommentPost.Text,
                Text = e.Text
            }).ToList();
            return returnList;
        }
        public void UpdateComment(CommentUpdateModel commentToUpdate)
        {
            var entity = _ctx.Comments.Single(e => e.CommentId == commentToUpdate.CommentId);
            if (entity != null)
            {
                if (commentToUpdate.UpdatedPostId != null)
                    entity.PostId = (int)commentToUpdate.UpdatedPostId;
                if (commentToUpdate.UpdatedText != null)
                    entity.Text = commentToUpdate.UpdatedText;
                _ctx.SaveChanges();
            }
        }
        public void RemoveComment(CommentDeleteModel commentToDelete)
        {
            var entity = _ctx.Comments.Single(e => e.CommentId == commentToDelete.CommentId);
            _ctx.Comments.Remove(entity);
            _ctx.SaveChanges();
        }
    }
}
