using OccupationalTherapist_Core.Enums;
using OccupationalTherapist_Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_Dtos.Posts
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Description { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<string> VideoUrls { get; set; }
        public int Likes { get; set; }
        public int Shares { get; set; }
        public PostStatus PostStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UserId { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
