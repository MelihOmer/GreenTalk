using GreenTalk.Application.Interfaces.Services;
using GreenTalk.Core.Entities;
using GreenTalk.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace GreenTalk.Service.Services
{
    public class Service<T> : IService<T> where T : BaseEntity, new()
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public DbSet<T> Table => _repository.Table;

        public async Task DeleteByIdAsync(Guid id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IQueryable<T> GetQueryable()
        {
            return _repository.GetQueryable();
        }

        public async Task<IEnumerable<T>> GetWhereAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return await _repository.GetWhereAsync(filter);
        }

        public async Task SaveAsync(T entity)
        {
            
            await _repository.SaveAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
