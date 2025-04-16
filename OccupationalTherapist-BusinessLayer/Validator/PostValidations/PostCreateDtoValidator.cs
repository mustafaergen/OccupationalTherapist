using FluentValidation;
using OccupationalTherapist_Dtos.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_BusinessLayer.Validator.PostValidations
{
    public class PostCreateDtoValidator : AbstractValidator<PostCreateDto>
    {
        public PostCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(5, 150).WithMessage("Title must be between 5 and 150 characters.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .Length(20, 5000).WithMessage("Content must be between 20 and 5000 characters.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");

            RuleForEach(x => x.ImageUrls)
                .Must(url => url.EndsWith(".jpg") || url.EndsWith(".jpeg") || url.EndsWith(".png") || url.EndsWith(".gif"))
                .WithMessage("Images must be in .jpg, .jpeg, .png, or .gif format.");

            RuleForEach(x => x.VideoUrls)
                .Must(url => url.EndsWith(".mp4") || url.EndsWith(".webm") || url.EndsWith(".mov") || url.EndsWith(".avi") || url.EndsWith(".mkv"))
                .WithMessage("Videos must be in .mp4, .webm, .mov, .avi, or .mkv format.");
        }
    }
}
