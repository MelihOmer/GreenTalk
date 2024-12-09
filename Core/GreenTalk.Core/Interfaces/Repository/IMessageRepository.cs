using GreenTalk.Core.Entities;

namespace GreenTalk.Core.Interfaces.Repository
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<IEnumerable<Message>> GetMessagesByUserIdAsync(Guid userId);
    }
}
