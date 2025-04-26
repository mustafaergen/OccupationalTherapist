using OccupationalTherapist_Core.Entities;
using OccupationalTherapist_DataAccess.EFCore.Abstracts;
using OccupationalTherapist_DataAccess.Interface.Repositories;
using OccupationalTherapist_DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_DataAccess.EFCore.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly AppDbContext _context;
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public int GetPostCommentsCountByPostId(int postId)
        {
            var postCommentCount = _context.Set<Comment>()
                .Count(c => c.PostId == postId);

            return postCommentCount;
        }


        public int GetPostLikesCountByPostId(int postId)
        {
            var postLikes = _context.Set<Post>()
                .Where(p => p.Id == postId)
                .Select(p => (int?)p.Likes) 
                .FirstOrDefault();

            if (postLikes == null)
            {
                throw new Exception($"Post with ID {postId} not found.");
            }

            return postLikes.Value;
        }
    }
}
