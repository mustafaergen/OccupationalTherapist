using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OccupationalTherapist_Core.Abstracts;

namespace OccupationalTherapist_Core.Entities
{
    public class Comment : BaseEntity
    {

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }

}
