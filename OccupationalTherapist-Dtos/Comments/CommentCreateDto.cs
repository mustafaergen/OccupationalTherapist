using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_Dtos.Comments
{
    public class CommentCreateDto
    {
        public string Content { get; set; }

        public List<string>? ImageUrls { get; set; }
        public List<string>? VideoUrls { get; set; }

        public int PostId { get; set; }
        public string UserId { get; set; }

        public int? ParentCommentId { get; set; }  
    }

}
