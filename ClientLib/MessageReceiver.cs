using System;
using Common;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientLib
{
    public static class MessageReceiver
    {
        public static void GlobalMessageHandler(this HubConnection connection)
        {
            connection.MessageHandler<GlobalMessageDto>(HubConstants.MessageHub.Global, dto => { Console.WriteLine($"[{dto.Sender}]: {dto.Message}"); });
        }

        public static void ChannelMessageHandler(this HubConnection connection)
        {
            connection.MessageHandler<ChannelMessageDto>(HubConstants.MessageHub.Channel, dto => { Console.WriteLine($"({dto.Channel})[{dto.Sender}]: {dto.Message}"); });
        }
        
        public static void PrivateMessageHandler(this HubConnection connection)
        {
            connection.MessageHandler<GlobalMessageDto>(HubConstants.MessageHub.Private, dto => { Console.WriteLine($"(PM)[{dto.Sender}]: {dto.Message}"); });
        }
    }
}