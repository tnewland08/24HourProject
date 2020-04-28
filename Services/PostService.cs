using Data;
using Models.PullModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PostService
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public void CreatePost(PostCreateModel postToCreate)
        {
            var entity = new Post()
            {
                UserId = _userId,
                Text = postToCreate.Text,
                Title = postToCreate.Title
            };
            _ctx.Posts.Add(entity);
            _ctx.SaveChanges();
        }
        public IEnumerable<PostListItem> GetPosts()
        {
            var returnList = _ctx.Posts.Select(e => new PostListItem
            {
                Title = e.Title,
                Text = e.Text,
                AuthorName = e.Author.Name
            }).ToList();
            return returnList;
        }
        public void UpdatePost(PostUpdateModel postToUpdate)
        {
            var entity = _ctx.Posts.Single(e => e.PostId == postToUpdate.PostId);
            if (entity != null)
            {
                if (postToUpdate.UpdatedText != null)
                    entity.Text = postToUpdate.UpdatedText;
                if (postToUpdate.UpdatedTitle != null)
                    entity.Title = postToUpdate.UpdatedTitle;
                _ctx.SaveChanges();
            }
        }
        public void RemovePost(PostDeleteModel postToDelete)
        {
            var entity = _ctx.Posts.Single(e => e.PostId == postToDelete.PostId);
            _ctx.Posts.Remove(entity);
            _ctx.SaveChanges();
        }
    }
}
