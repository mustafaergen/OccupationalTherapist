using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OccupationalTherapist_Core.Abstracts;
using OccupationalTherapist_Core.Enums;

namespace OccupationalTherapist_Core.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> ImageUrl { get; set; } = new List<string>();
        public List<string> VideoUrl { get; set; } = new List<string>();
        public int Likes { get; set; }
        public int Shares { get; set; }
        public List<Comment> Comment { get; set; } = new List<Comment>();
        public PostStatus PostStatus { get; set; } = PostStatus.Draft; 
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
