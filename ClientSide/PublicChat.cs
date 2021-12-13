using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using ClientLib;

namespace ClientSide
{
    public class PublicChat : IChat
    {
        private readonly IMessageSender _sender;
        public PublicChat(IMessageSender sender)
        {
            _sender = sender;
        }

        public async Task ConnectTo(HubConnection connection)
        {
            await connection.StartAsync();

            connection.GlobalMessageHandler();
            connection.ChannelMessageHandler();
            connection.PrivateMessageHandler();

            while (true)
            {
                Console.WriteLine("Send a message to the chat: ");
                var message = Console.ReadLine();
                if (string.IsNullOrEmpty(message))
                {
                    continue;
                }
                if (message == "exit")
                {
                    return;
                }

                await _sender.SendToGlobalAsync(connection, message);
            }
        }
    }

    public interface IChat
    {
        Task ConnectTo(HubConnection connection);
    }
}