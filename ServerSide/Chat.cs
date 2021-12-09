using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace ServerSide
{
    public class Chat : Hub
    {
        public async Task SendMessageInChat(string nick, string message)
        {
            Console.WriteLine($"We found those parameter: {nick}, {message}");
            await Clients.All.SendAsync("NewMessageInChat", nick, message);
        }
    }
}
