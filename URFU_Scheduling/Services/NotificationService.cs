using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace URFU_Scheduling.Services
{
    public class NotificationService : INotificationService
    {
        private readonly BaseRepository<Notification> _notificationRepo;
        private readonly UserRepository _userRepository;

        public NotificationService(
            BaseRepository<Notification> notificationRepository,
            UserRepository userRepository)
        {
            _userRepository = userRepository;
            _notificationRepo = notificationRepository;
        }

        public void SendNotification(INotificationProvider provider, string message, User user)
        {
            provider.Send(message, user);
        }

    }

    // [Authorize]
    public class NotificationHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("Receive", message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} подключен");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} подключен");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
