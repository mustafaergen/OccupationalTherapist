using Microsoft.EntityFrameworkCore;
using OccupationalTherapist_Core.Abstracts;
using OccupationalTherapist_DataAccess.Interface.Abstracts;
using OccupationalTherapist_DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_DataAccess.EFCore.Abstracts
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(T entity)
        {
            await _context.AddAsync(entity);
            return await SaveChange();
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Remove(entity);
            return await SaveChange();

        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> FindAllCondition(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition);
        }

        public async Task<T?> FindByCondition(Expression<Func<T, bool>> condition)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(condition);
        }

        public async Task<T?> FindById(int id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveChange()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(T entity)
        {
            _context.Update(entity);
            return await SaveChange();
        }
    }
}
