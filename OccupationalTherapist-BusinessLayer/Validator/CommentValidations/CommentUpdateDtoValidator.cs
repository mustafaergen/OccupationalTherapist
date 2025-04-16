using FluentValidation;
using OccupationalTherapist_Dtos.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_BusinessLayer.Validator.CommentValidations
{
    public class CommentUpdateDtoValidator : AbstractValidator<CommentUpdateDto>
    {
        public CommentUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Invalid comment ID.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Comment content cannot be empty.")
                .MaximumLength(1000).WithMessage("Comment must be at most 1000 characters.");
        }
    }
}
