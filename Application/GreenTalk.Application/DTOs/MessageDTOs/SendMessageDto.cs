namespace GreenTalk.Application.DTOs.MessageDTOs
{
    public class SendMessageDto
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
    }
}
