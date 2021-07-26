using System;
using System.Linq;
using System.Threading.Tasks;
using FinanceSystem.Application.Interfaces.Base;
using FinanceSystem.Infrastructure.Interfaces.Base;
using FinanceSystem.Infrastructure.Models;
using FinanceSystem.Infrastructure.Models.Base;

namespace FinanceSystem.Application.Actions
{
    public class GenericAction <TEntity> : IGenericAction<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public GenericAction(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _baseRepository.GetById(id);
        }

        public async Task<bool> Post(TEntity newEntity)
        {
            await _baseRepository.Post(newEntity);
            return await _baseRepository.SaveChanges();
        }

        public async Task<bool> Put(TEntity editEntity)
        {
            await _baseRepository.Put(editEntity);
            return await _baseRepository.SaveChanges();
        }

        public async Task<bool> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            return await _baseRepository.SaveChanges();
        }
    }
}