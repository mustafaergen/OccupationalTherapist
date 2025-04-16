using OccupationalTherapist_Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OccupationalTherapist_DataAccess.Interface.Abstracts
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindAllCondition(Expression<Func<T, bool>> condition);
        Task<T?> FindById(int id);
        Task<T?> FindByCondition(Expression<Func<T, bool>> condition);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> SaveChange();
    }
}
