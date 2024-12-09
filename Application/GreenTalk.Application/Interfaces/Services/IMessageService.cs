using GreenTalk.Application.DTOs.MessageDTOs;
using GreenTalk.Core.Entities;

namespace GreenTalk.Application.Interfaces.Services
{
    public interface IMessageService : IService<Message>
    {
        Task SendMessage(SendMessageDto message);
        Task<IEnumerable<Message>> GetMessagesByUserIdAsync(Guid userId);
    }
}
