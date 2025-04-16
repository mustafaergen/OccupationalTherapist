using OccupationalTherapist_Core.Abstracts;
using OccupationalTherapist_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_Core.Entities
{
    public class Appointment : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
