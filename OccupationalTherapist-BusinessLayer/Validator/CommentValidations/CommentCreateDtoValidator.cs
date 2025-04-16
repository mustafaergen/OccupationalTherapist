using FluentValidation;
using OccupationalTherapist_Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_BusinessLayer.Validator.CommentValidations
{
    public class CommentCreateDtoValidator : AbstractValidator<CommentCreateDto>
    {
        public CommentCreateDtoValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Comment content cannot be empty.")
                .MaximumLength(1000).WithMessage("Comment must be at most 1000 characters.");

            RuleFor(x => x.PostId)
                .GreaterThan(0).WithMessage("Invalid post ID.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");
        }
    }
}
