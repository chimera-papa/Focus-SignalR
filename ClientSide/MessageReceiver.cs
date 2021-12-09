using Microsoft.AspNetCore.SignalR.Client;

namespace ClientSide
{
    public static class MessageReceiver
    {
        private const string MessageReceived = "NewMessageInChat";
        public static void RegisterHandler(HubConnection connection)
        {
            connection.On(MessageReceived, (string nick, string message) =>
            {
                System.Console.WriteLine($"{nick} say {message}");
            });
        }
    }
}