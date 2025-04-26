using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_BusinessLayer.Managers.Abstract
{
    using OccupationalTherapist_Core.Entities;
    using OccupationalTherapist_Core.Enums;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace OccupationalTherapist_Business.Interfaces
    {
        public interface IAppointmentService
        {
            Task<Appointment> GetAppointmentByIdAsync(int id);
            Task<List<Appointment>> GetAllAppointmentsAsync();
            Task<List<Appointment>> GetAppointmentsByUserIdAsync(string userId);

            Task<Appointment> CreateAppointmentAsync(Appointment appointment);
            Task UpdateAppointmentAsync(Appointment appointment);
            Task DeleteAppointmentAsync(int id);

            Task<List<Appointment>> GetAppointmentsByStatusAsync(AppointmentStatus status);

            Task<List<Appointment>> GetUpcomingAppointmentsAsync();
            Task<List<Appointment>> GetPastAppointmentsAsync();

            Task<List<Appointment>> GetUpcomingAppointmentsByUserIdAsync(string userId);

            Task RescheduleAppointmentAsync(int id, DateTime newStartTime, DateTime newEndTime);

            Task<List<Appointment>> GetAppointmentsBetweenDatesAsync(DateTime startDate, DateTime endDate);
        }
    }

}
