using GreenTalk.Application.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;

namespace GreenTalk.API.SignalrHubs
{
    public class ChatHub : Hub
    {
        private static readonly Dictionary<string, Object> OnlineUsers = new();
        private readonly IUserService _userService;

        public ChatHub(IUserService userService)
        {
            _userService = userService;
        }

        public override async Task<Task> OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
            {
                var user = await _userService.GetByIdAsync(Guid.Parse(userId));
                lock (OnlineUsers)
                {
                    if (!OnlineUsers.ContainsKey(userId))
                    {
                        OnlineUsers[userId] = new { ConnectionId = Context.ConnectionId, Username = user.Username };
                    }
                }
            }
            await Clients.All.SendAsync("UpdateOnlineUsers", OnlineUsers.ToList());

            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(userId))
            {
                lock (OnlineUsers)
                {
                    if (OnlineUsers.ContainsKey(userId))
                    {
                        OnlineUsers.Remove(userId); // Bağlantı sonlandığında kullanıcıyı kaldır
                    }
                }
            }

            // Online kullanıcılar listesi güncellenir
            Clients.All.SendAsync("UpdateOnlineUsers", OnlineUsers.Keys.ToList());
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(string senderId, string receiverId, string message)
        {
            await Clients.User(receiverId).SendAsync("ReceiveMessage", senderId, message);
        }
    }
}
