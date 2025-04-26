using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OccupationalTherapist_BusinessLayer.Managers.Abstract;
using OccupationalTherapist_BusinessLayer.Managers.Abstract.OccupationalTherapist_Business.Interfaces;
using OccupationalTherapist_Core.Entities;
using OccupationalTherapist_Core.Enums;
using OccupationalTherapist_DataAccess.Interface.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_BusinessLayer.Managers.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> userManager;

        public AppointmentManager(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            var user = await userManager.FindByIdAsync(appointment.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {appointment.UserId} not found.");
            }

            appointment.UserId = user.Id;
            appointment.CreatedAt = DateTime.UtcNow;
            appointment.UpdatedAt = DateTime.UtcNow;

            _repositoryManager.Appointment.Create(appointment);
            await _repositoryManager.SaveAsync();

            return appointment;
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment = await _repositoryManager.Appointment.FindById(id); 

            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }

            await _repositoryManager.Appointment.Delete(appointment);

            await _repositoryManager.SaveAsync();
        }




        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            var appointments =  _repositoryManager.Appointment.FindAll(); 
            if (appointments == null || !appointments.Any())
            {
                throw new KeyNotFoundException("No appointments found.");
            }

            return _mapper.Map<List<Appointment>>(appointments);
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _repositoryManager.Appointment.FindById(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }

            return _mapper.Map<Appointment>(appointment); 
        }

        public async Task<List<Appointment>> GetAppointmentsBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            var appointments = _repositoryManager.Appointment.FindAll();
            var filteredAppointments = appointments
                .Where(a => a.StartTime >= startDate && a.EndTime <= endDate)
                .ToList();

            return filteredAppointments;
        }

        public async Task<List<Appointment>> GetAppointmentsByStatusAsync(AppointmentStatus status)
        {
            var appointments = _repositoryManager.Appointment.FindAll();
            var filteredAppointments = appointments
                .Where(a => a.Status == status)
                .ToList();

            return filteredAppointments;
        }

        public async Task<List<Appointment>> GetAppointmentsByUserIdAsync(string userId)
        {
            var appointments = _repositoryManager.Appointment.FindAll();
            var userAppointments = appointments
                .Where(a => a.UserId == userId)
                .ToList();

            return userAppointments;
        }

        public async Task<List<Appointment>> GetPastAppointmentsAsync()
        {
            var appointments = _repositoryManager.Appointment.FindAll();
            var pastAppointments = appointments
                .Where(a => a.EndTime < DateTime.UtcNow)
                .ToList();

            return pastAppointments;
        }

        public async Task<List<Appointment>> GetUpcomingAppointmentsAsync()
        {
            var appointments = _repositoryManager.Appointment.FindAll();
            var upcomingAppointments = appointments
                .Where(a => a.StartTime > DateTime.UtcNow)
                .ToList();

            return upcomingAppointments;
        }

        public async Task<List<Appointment>> GetUpcomingAppointmentsByUserIdAsync(string userId)
        {
            var appointments = _repositoryManager.Appointment.FindAll();
            var userUpcomingAppointments = appointments
                .Where(a => a.UserId == userId && a.StartTime > DateTime.UtcNow)
                .ToList();

            return userUpcomingAppointments;
        }

        public async Task RescheduleAppointmentAsync(int id, DateTime newStartTime, DateTime newEndTime)
        {
            var appointment = await _repositoryManager.Appointment.FindById(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found.");
            }

            appointment.StartTime = newStartTime;
            appointment.EndTime = newEndTime;
            appointment.UpdatedAt = DateTime.UtcNow;

            _repositoryManager.Appointment.Update(appointment);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            var existingAppointment = await _repositoryManager.Appointment.FindById(appointment.Id);
            if (existingAppointment == null)
            {
                throw new KeyNotFoundException($"Appointment with ID {appointment.Id} not found.");
            }

            existingAppointment.StartTime = appointment.StartTime;
            existingAppointment.EndTime = appointment.EndTime;
            existingAppointment.Status = appointment.Status;
            existingAppointment.UpdatedAt = DateTime.UtcNow;

            _repositoryManager.Appointment.Update(existingAppointment);
            await _repositoryManager.SaveAsync();
        }
    }
}
