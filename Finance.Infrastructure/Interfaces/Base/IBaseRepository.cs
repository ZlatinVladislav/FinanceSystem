using System;
using System.Linq;
using System.Threading.Tasks;
using FinanceSystem.Infrastructure.Models.Base;

namespace FinanceSystem.Infrastructure.Interfaces.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(Guid id);
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> Post(TEntity newIncome);
        Task<TEntity> Put(TEntity editIncome);
        Task Delete(Guid id);
        Task<bool> SaveChanges();
    }
}