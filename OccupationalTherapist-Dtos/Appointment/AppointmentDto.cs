using OccupationalTherapist_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_Dtos.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FullName { get; set; }
    }
}
