using Microsoft.EntityFrameworkCore;
using OccupationalTherapist_Core.Entities;
using OccupationalTherapist_DataAccess.EFCore.Abstracts;
using OccupationalTherapist_DataAccess.Interface.Repositories;
using OccupationalTherapist_DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_DataAccess.EFCore.Repositories
{
    internal class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public int GetCommentCountByPostId(int postId)
        {
            return _context.Set<Comment>()
                .Count(c => c.PostId == postId);
        }


        public int GetCommentLikesCountByPostId(int postId)
        {
            var totalLikes = _context.Set<Comment>().Where(c => c.PostId == postId).Sum(c => (int?)c.Likes) ?? 0;

            return totalLikes;
        }

        public IQueryable<Comment> GetCommentsWithDetails()
        {
            return _context.Set<Comment>()
                .Include(c => c.User)
                .Include(c => c.Post)
                .ThenInclude(p => p.User)
                .Include(c => c.Replies)
                .ThenInclude(r => r.User);
        }

    }
}
