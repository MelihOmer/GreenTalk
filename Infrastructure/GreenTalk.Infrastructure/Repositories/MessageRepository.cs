using GreenTalk.Core.Entities;
using GreenTalk.Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace GreenTalk.Infrastructure.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly AppDbContext _context;
        public MessageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetMessagesByUserIdAsync(Guid userId)
        {
            return await Table
                .Where(x => x.SenderId == userId || x.ReceiverId == userId)
                .ToListAsync();
        }
    }
}
