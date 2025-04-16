using OccupationalTherapist_DataAccess.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_DataAccess.Interface.UnitOfWork
{
    public interface IRepositoryManager
    {
        ICommentRepository Comment { get; }
        IAppointmentRepository Appointment { get; }
        IPostRepository Post { get; }
        Task SaveAsync();
        void Save();
    }
}
