using FluentValidation;
using OccupationalTherapist_Dtos.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_BusinessLayer.Validator.AppointmentValidations
{
    public class AppointmentUpdateDtoValidator : AbstractValidator<AppointmentUpdateDto>
    {
        public AppointmentUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Invalid appointment ID.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description can be at most 1000 characters.");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required.")
                .MaximumLength(200).WithMessage("Location cannot exceed 200 characters.");

            RuleFor(x => x.StartTime)
                .GreaterThan(DateTime.Now).WithMessage("Start time must be in the future.");

            RuleFor(x => x.EndTime)
                .GreaterThan(x => x.StartTime).WithMessage("End time must be after start time.");
        }
    }
}
