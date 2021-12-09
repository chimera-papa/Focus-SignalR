using System;
using Common;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientLib
{
    public static class MessageReceiver
    {
        public static void GlobalMessageHandler<T>(this HubConnection connection, Action<T> action)
        {
            connection.On(HubConstants.MessageHub.Global, action);
        }

        public static void ChannelMessageHandler(this HubConnection connection, Action<string, string, string> action)
        {
            connection.On(HubConstants.MessageHub.Channel, action);
        }
        
        public static void PrivateMessageHandler(this HubConnection connection, Action<string, string> action)
        {
            connection.On(HubConstants.MessageHub.Private, action);
        }
    }
}