﻿using OccupationalTherapist_Core.Entities;
using OccupationalTherapist_DataAccess.Interface.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_DataAccess.Interface.Repositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        IQueryable<Comment> GetCommentsWithDetails();
        int GetCommentCountByPostId(int postId);
        int GetCommentLikesCountByPostId(int postId);
    }
}
