using GreenTalk.Application.DTOs.MessageDTOs;
using GreenTalk.Core.Entities;
using GreenTalk.Core.Interfaces.Repository;

namespace GreenTalk.Application.UseCase.Messages
{
    public class SendMessageUseCase
    {
        private readonly IMessageRepository _messageRepository;

        public SendMessageUseCase(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task ExecuteAsync(SendMessageDto messageDto)
        {
            if (!string.IsNullOrEmpty(messageDto.Content))
            {
                Message message = new()
                {
                    Content = messageDto.Content,
                    ReceiverId = messageDto.ReceiverId,
                    SenderId = messageDto.SenderId,
                    SentAt  = DateTime.UtcNow
                };
                await _messageRepository.SaveAsync(message);
            }
        }
    }
}
