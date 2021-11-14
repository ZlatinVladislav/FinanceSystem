using System;
using System.Linq;
using System.Threading.Tasks;
using FinanceSystem.Infrastructure.Models.Base;

namespace FinanceSystem.Application.Interfaces.Base
{
    public interface IGenericAction<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(Guid id);
        Task<IQueryable<TEntity>> GetAll();
        Task<bool> Post(TEntity newEntity);
        Task<bool> Put(TEntity editEntity);
        Task<bool> Delete(Guid id);
    }
}