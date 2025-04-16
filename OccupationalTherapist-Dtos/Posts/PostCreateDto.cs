using OccupationalTherapist_Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_Dtos.Posts
{
    public class PostCreateDto
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public string? Description { get; set; }
        public List<string>? ImageUrls { get; set; }
        public List<string>? VideoUrls { get; set; }
        public PostStatus PostStatus { get; set; } = PostStatus.Draft;
        public string UserId { get; set; }

    }
}
