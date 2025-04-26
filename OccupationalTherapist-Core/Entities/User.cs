
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace OccupationalTherapist_Core.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string? ProfilePictureUrl { get; set; } = "defaultUser.png";
        public string? Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Location { get; set; } = string.Empty;
        public int? Age
        {
            get
            {
                if (DateOfBirth == null)
                    return null;

                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Value.Year;
                if (DateOfBirth.Value.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
        public ICollection<Post>? Posts { get; set; } = new List<Post>();
        public ICollection<Appointment>? Appointment { get; set; } = new List<Appointment>();
        public ICollection<Comment>? Comments { get; set; } = new List<Comment>();
    }
}
