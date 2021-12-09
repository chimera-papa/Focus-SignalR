using System.Threading.Tasks;
using Common.Notification;
using Microsoft.AspNetCore.SignalR;

namespace ServerSide.Hubs
{
    public class NotificationHub : Hub
    {
        
    }

    public interface INotificationHub
    {
        Task SendGlobal(GlobalNotificationDto notificationDto);
    }
}