using GreenTalk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GreenTalk.Application.Interfaces.Services
{
    public interface IService<T> where T : BaseEntity,new()
    {
        public DbSet<T> Table { get; }
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(Guid id);
        IQueryable<T> GetQueryable();
        Task SaveAsync(T entity);
        Task DeleteByIdAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}
