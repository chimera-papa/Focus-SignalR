using System;
using System.Threading.Tasks;
using Common;
using Common.Notification;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientSide
{
    public class Notification : INotification
    {
        public Action<string> GlobalListener { get; set; }
        
        public async Task Setup(string basePath)
        {
            var connection = new HubConnectionBuilder().WithUrl($"{basePath}/{HubConstants.NotificationHub.Name}").Build();
            await connection.StartAsync();
            connection.On(HubConstants.NotificationHub.Global, (string notification) =>
            {
                Console.WriteLine($"Receiving global message {notification}");
                GlobalListener(notification);
            });
        }
    }

    public interface INotification
    {
        Action<string> GlobalListener { get; set; }
        
        Task Setup(string basePath);
    }
}