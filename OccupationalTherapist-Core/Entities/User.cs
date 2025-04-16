using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_Core.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string ProfilePictureUrl { get; set; } = "defaultUser.png";
        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; } = string.Empty;
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Appointment> Appointment { get; set; } = new List<Appointment>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
