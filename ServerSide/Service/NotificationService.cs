using System;
using System.Threading.Tasks;
using Common;
using Common.Notification;
using Microsoft.AspNetCore.SignalR;
using ServerSide.Hubs;

namespace ServerSide.Service
{
    public class NotificationService
    {
        
        private readonly IHubContext<NotificationHub> _notificationHub;

        public NotificationService(IHubContext<NotificationHub> notificationHub)
        {
            _notificationHub = notificationHub;
        }

        public Task GlobalNotification(string message)
        {
            Console.WriteLine($"Sending global notification {message}");
            return _notificationHub.Clients.All.SendAsync(HubConstants.NotificationHub.Global, message);
        }

        public Task ChannelNotification(string channel, string message)
        {
            Console.WriteLine($"Sending global notification {message}");
            return _notificationHub.Clients.Groups(channel).SendAsync(HubConstants.NotificationHub.Global, message);
        }
    }
}