using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;

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
}
