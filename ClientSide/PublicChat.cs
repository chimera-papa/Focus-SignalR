using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using ClientLib;
using Common;

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

            connection.GlobalMessageHandler<MessageDto>(dto => { Console.WriteLine($"[{dto.Sender}]: {dto.Message}"); });
            connection.ChannelMessageHandler(
                (sender, channel, message) => { Console.WriteLine($"({channel})[{sender}]: {message}"); });
            connection.PrivateMessageHandler(
                (sender, message) => { Console.WriteLine($"(PM)[{sender}]: {message}"); });

            while (true)
            {
                Console.WriteLine("Send a message to the chat: ");
                var message = Console.ReadLine();
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