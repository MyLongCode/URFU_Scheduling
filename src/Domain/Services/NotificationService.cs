using URFU_Scheduling.Domain.Entities;
using URFU_Scheduling.Domain.Interfaces;
using URFU_Scheduling.Domain.Repositories;

namespace URFU_Scheduling.Domain.Services
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
