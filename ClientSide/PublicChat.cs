using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ClientSide
{
    public class PublicChat : IChat
    {
        private readonly ISender _sender;
        public PublicChat(ISender sender)
        {
            _sender = sender;
        }

        public async Task ConnectTo(HubConnection connection)
        {
            await connection.StartAsync();

            while (true)
            {
                Console.WriteLine("Send a message to the chat: ");
                var message = Console.ReadLine();

                await _sender.SendMessageAsync(connection, message);
            }
        }
    }

    public interface IChat
    {
        Task ConnectTo(HubConnection connection);
    }
}