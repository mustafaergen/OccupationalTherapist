using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OccupationalTherapist_BusinessLayer.Managers.Abstract;
using OccupationalTherapist_Core.Entities;
using OccupationalTherapist_DataAccess.Interface.UnitOfWork;
using OccupationalTherapist_Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OccupationalTherapist_BusinessLayer.Managers.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> userManager;

        public CommentManager(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            this.userManager = userManager;
        }

        public async Task CreateCommentAsync(CommentCreateDto commentCreateDto)
        {
            var comment = _mapper.Map<Comment>(commentCreateDto);
            comment.CreatedAt = DateTime.UtcNow;

            // Set the UserId after fetching the User.
            var user = await userManager.FindByIdAsync(commentCreateDto.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {commentCreateDto.UserId} not found.");
            }

            comment.UserId = user.Id;
            await _repositoryManager.Comment.Create(comment);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await _repositoryManager.Comment.FindByCondition(c => c.Id == commentId);

            if (comment == null)
            {
                throw new KeyNotFoundException($"Comment with ID {commentId} not found.");
            }

            _repositoryManager.Comment.Delete(comment);
            await _repositoryManager.SaveAsync();
        }

        public async Task<CommentDto> GetCommentByIdAsync(int commentId)
        {
            var comment = await _repositoryManager.Comment.FindByCondition(c => c.Id == commentId);

            if (comment == null)
            {
                throw new KeyNotFoundException($"Comment with ID {commentId} not found.");
            }

            return _mapper.Map<CommentDto>(comment);
        }

        public int GetCommentCountByPostIdAsync(int postId)
        {
            var commentCount = _repositoryManager.Comment.GetCommentCountByPostId(postId);
            if (commentCount == 0) 
            {
                throw new KeyNotFoundException($"No comments found for post with ID {postId}.");
            }
            return commentCount;
        }

        public int GetCommentLikesCountByPostId(int postId)
        {
            var commentsLikes = _repositoryManager.Comment.GetCommentLikesCountByPostId(postId);

            if (commentsLikes == 0) 
            {
                throw new KeyNotFoundException($"No comments found for post with ID {postId}.");
            }

            return commentsLikes;
        }


        public async Task<List<CommentDto>> GetCommentsByPostIdAsync(int postId)
        {
            var comments = await _repositoryManager.Comment.FindByCondition(c => c.PostId == postId);

            if (comments is null)
            {
                throw new KeyNotFoundException($"No comments found for post with ID {postId}.");
            }

            return _mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<List<CommentDto>> GetCommentsByUserIdAsync(string userId)
        {
            var comments = await _repositoryManager.Comment.FindByCondition(c => c.UserId == userId);

            if (comments is null)
            {
                throw new KeyNotFoundException($"No comments found for user with ID {userId}.");
            }

            return _mapper.Map<List<CommentDto>>(comments);
        }

        public async Task UpdateCommentAsync(CommentUpdateDto commentUpdateDto)
        {
            var comment = await _repositoryManager.Comment.FindByCondition(c => c.Id == commentUpdateDto.Id);

            if (comment == null)
            {
                throw new KeyNotFoundException($"Comment with ID {commentUpdateDto.Id} not found.");
            }

            comment = _mapper.Map(commentUpdateDto, comment);
            comment.UpdatedAt = DateTime.UtcNow;

            _repositoryManager.Comment.Update(comment);
            await _repositoryManager.SaveAsync();
        }
    }
}
