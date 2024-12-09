using GreenTalk.Core.Entities;
using GreenTalk.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace GreenTalk.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await Table.Where(x => x.Username == username).FirstOrDefaultAsync();
        }
    }
}
