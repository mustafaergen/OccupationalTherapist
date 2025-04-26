using AutoMapper;
using Microsoft.AspNet.Identity;
using OccupationalTherapist_BusinessLayer.Managers.Abstract;
using OccupationalTherapist_Core.Entities;
using OccupationalTherapist_DataAccess.Interface.UnitOfWork;
using OccupationalTherapist_Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_BusinessLayer.Managers.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> userManager;

        public PostManager(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager)
        {
            this._repositoryManager = repositoryManager;
            this._mapper = mapper;
            this.userManager = userManager;
        }

        public async Task CreatePostAsync(PostCreateDto postCreateDto)
        {
            if (postCreateDto == null)
                throw new ArgumentNullException(nameof(postCreateDto));

            var post = _mapper.Map<Post>(postCreateDto);
            post.CreatedAt = DateTime.UtcNow;
            post.UpdatedAt = DateTime.UtcNow;

            _repositoryManager.Post.Create(post);
            await _repositoryManager.SaveAsync();
        }


        public async Task DeletePostAsync(int postId)
        {
            var post = await _repositoryManager.Post.FindById(postId);
            if (post != null)
            {
                _repositoryManager.Post.Delete(post);
                _repositoryManager.SaveAsync();
            }
            else
            {
                throw new KeyNotFoundException(nameof(postId));
            }
        }

        public async Task<List<PostDto>> GetAllPostsAsync()
        {
            var posts = _repositoryManager.Post.FindAll();
            if (posts != null)
            {
                var postDtos = _mapper.Map<List<PostDto>>(posts.ToList());
                return await Task.FromResult(postDtos);
            }
            else
            {
                throw new ArgumentNullException(nameof(posts));
            }
        }

        public async Task<PostDto> GetPostByIdAsync(int postId)
        {
            var post = _repositoryManager.Post.FindById(postId);
            if (post != null)
            {
                var postDto = _mapper.Map<PostDto>(post);
                return await Task.FromResult(postDto);
            }
            else
            {
                throw new ArgumentNullException(nameof(postId));
            }
        }

        public int GetPostCommentsCountByPostId(int postId)
        {
            return _repositoryManager.Post.GetPostCommentsCountByPostId(postId);
        }

        public int GetPostLikesCountByPostId(int postId)
        {
            return _repositoryManager.Post.GetPostLikesCountByPostId(postId);
        }

        public async Task<List<PostDto>> GetPostsByUserIdAsync(string userId)
        {
            var post = _repositoryManager.Post.FindByCondition(x => x.UserId == userId);
            if (post != null)
            {
                var postDtos = _mapper.Map<List<PostDto>>(post);
                return await Task.FromResult(postDtos);
            }
            else
            {
                throw new ArgumentNullException(nameof(userId));
            }

        }

        public async Task<List<PostDto>> SearchPostsAsync(string keyword)
        {
            var postByKeyword = _repositoryManager.Post.FindByCondition(x => x.Title.Contains(keyword) || x.Content.Contains(keyword));
            if (postByKeyword != null)
            {
                var postDtos = _mapper.Map<List<PostDto>>(postByKeyword);
                return await Task.FromResult(postDtos);
            }
            else
            {
                throw new ArgumentNullException(nameof(keyword));
            }
        }

        public async Task UpdatePostAsync(PostUpdateDto postUpdateDto)
        {
            if (postUpdateDto == null)
                throw new ArgumentNullException(nameof(postUpdateDto));

            var post = await _repositoryManager.Post.FindById(postUpdateDto.PostId);
            if (post == null)
                throw new KeyNotFoundException($"Post with ID {postUpdateDto.PostId} not found.");

            _mapper.Map(postUpdateDto, post); 
            post.UpdatedAt = DateTime.UtcNow;

            _repositoryManager.Post.Update(post);
            await _repositoryManager.SaveAsync();
        }
    }
}
