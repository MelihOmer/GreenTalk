using GreenTalk.Core.Entities;
using GreenTalk.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GreenTalk.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table { get => _context.Set<T>(); }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> filter)
        {
            var query = await Table.Where(filter).ToListAsync();
            return query;
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public IQueryable<T> GetQueryable()
        {
            return Table.AsQueryable();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task SaveAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }


    }
}
