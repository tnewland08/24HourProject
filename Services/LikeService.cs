using Data;
using Models.LikeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LikeService
    {
        //private readonly ApplicationDbContext _ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        public bool AddLike(LikeCreateModel like)
        {
            var entity = new Like()
            {
                UserId = _userId,
                PostId = like.PostId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
