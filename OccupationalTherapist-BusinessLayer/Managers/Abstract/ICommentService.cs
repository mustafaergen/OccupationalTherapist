using OccupationalTherapist_Dtos.Comments;
using OccupationalTherapist_Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_BusinessLayer.Managers.Abstract
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CommentCreateDto commentCreateDto);
        Task UpdateCommentAsync(CommentUpdateDto commentUpdateDto);
        Task DeleteCommentAsync(int commentId);
        Task<CommentDto> GetCommentByIdAsync(int commentId);
        Task<List<CommentDto>> GetCommentsByUserIdAsync(string userId);
        Task<List<CommentDto>> GetCommentsByPostIdAsync(int postId);
        int GetCommentCountByPostIdAsync(int postId);
        int GetCommentLikesCountByPostId(int postId);
    }

}
