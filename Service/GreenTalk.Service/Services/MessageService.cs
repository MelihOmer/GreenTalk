using GreenTalk.Application.DTOs.MessageDTOs;
using GreenTalk.Application.Interfaces.Services;
using GreenTalk.Application.UseCase.Messages;
using GreenTalk.Core.Entities;
using GreenTalk.Core.Interfaces.Repository;

namespace GreenTalk.Service.Services
{
    public class MessageService : Service<Message>, IMessageService
    {
        private readonly SendMessageUseCase _sendMessageUseCase;
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository repository, SendMessageUseCase sendMessageUseCase) : base(repository)
        {
            _messageRepository = repository;
            _sendMessageUseCase = sendMessageUseCase;
        }

        public async Task<IEnumerable<Message>> GetMessagesByUserIdAsync(Guid userId)
        {
            return await _messageRepository.GetMessagesByUserIdAsync(userId);
        }

        public async Task SendMessage(SendMessageDto message)
        {
            await _sendMessageUseCase.ExecuteAsync(message);
        }
    }
}
