using OccupationalTherapist_DataAccess.EFCore.Repositories;
using OccupationalTherapist_DataAccess.Interface.Repositories;
using OccupationalTherapist_DataAccess.Interface.UnitOfWork;
using OccupationalTherapist_DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_DataAccess.EFCore.UnitOfWork
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly ICommentRepository _commentRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPostRepository _postRepository;
        public RepositoryManager(AppDbContext context)
        {
            _context = context;
            _commentRepository = new CommentRepository(_context);
            _appointmentRepository = new AppointmentRepository(_context);
            _postRepository = new PostRepository(_context);
        }
        public ICommentRepository Comment => _commentRepository;

        public IAppointmentRepository Appointment => _appointmentRepository;

        public IPostRepository Post => _postRepository;

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
