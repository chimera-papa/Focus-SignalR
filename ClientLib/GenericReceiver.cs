using System;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientLib
{
    public static class GenericReceiver 
    {
        public static void MessageHandler<T>(this HubConnection connection, string methodName, Action<T> action)
        {
            connection.On(methodName, action);
        }
    }
}