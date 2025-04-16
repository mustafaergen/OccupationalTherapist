using OccupationalTherapist_Core.Entities;
using OccupationalTherapist_Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_BusinessLayer.Managers.Abstract
{
    public interface IPostService
    {
        Task CreatePostAsync(PostCreateDto postCreateDto);
        Task UpdatePostAsync(PostUpdateDto postUpdateDto);
        Task DeletePostAsync(int postId);
        Task<List<PostDto>> GetAllPostsAsync();
        Task<PostDto> GetPostByIdAsync(int postId);
        Task<List<PostDto>> GetPostsByUserIdAsync(string userId);
        Task<List<PostDto>> SearchPostsAsync(string keyword);
    }
}
