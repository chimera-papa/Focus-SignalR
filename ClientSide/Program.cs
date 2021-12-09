using System;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace ClientSide
{
    static class Program
    {
        private static async Task Main(string[] args)
        {
            var provider = ServiceBuilder.Build();

            var chat = provider.GetService<IChat>();
            var notification = provider.GetService<INotification>();

            const string baseUrl = "http://localhost:5001";
            var url = $"{baseUrl}/{HubConstants.MessageHub.Name}";

            var connection = new HubConnectionBuilder().AddMessagePackProtocol().WithUrl(url).Build();
            notification.GlobalListener += it => Console.WriteLine($"NOTIFICATION: {it}");

            await notification.Setup(baseUrl);
            await chat.ConnectTo(connection);
        }
    }
}