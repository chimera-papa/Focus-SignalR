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

            await Retry(notification, chat, 10);
        }

        private static async Task Retry(INotification notification, IChat chat, int numberOfTry)
        {
            try
            {
                await ConnectToChat(notification, chat);
            }
            catch (Exception e)
            {
                if (numberOfTry > 0)
                {
                    Console.WriteLine(e.Message);
                    await Retry(notification, chat, numberOfTry - 1);
                }
                else
                    throw;
            }
        }

        private static async Task ConnectToChat(INotification notification, IChat chat)
        {
            var baseUrl = GetBaseUrl();
            var url = $"{baseUrl}/{HubConstants.MessageHub.Name}";

            var connection = new HubConnectionBuilder().AddMessagePackProtocol().WithUrl(url).Build();
            notification.GlobalListener += it => Console.WriteLine($"NOTIFICATION: {it}");

            await notification.Setup(baseUrl);
            await chat.ConnectTo(connection);
        }

        private static string GetBaseUrl()
        {
            Console.WriteLine("Put connection string");
            var input = Console.ReadLine();
            const string baseUrl = "http://localhost:5000";

            return string.IsNullOrWhiteSpace(input) ? baseUrl : input;
        }
    }
}