using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_Core.VMs
{
    using System.ComponentModel.DataAnnotations;

    public class CommentCreateVM
    {
        [Required(ErrorMessage = "Yorum içeriği boş bırakılamaz.")]
        [StringLength(1000, ErrorMessage = "Yorum en fazla 1000 karakter olabilir.")]
        [Display(Name = "Yorum")]
        public string Content { get; set; }

        [Required]
        public int PostId { get; set; } 

        public string? UserId { get; set; } 
    }

}
