using System;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.SignalR;

namespace ServerSide.Hubs
{
    public class Message : Hub
    {
        [HubMethodName(HubConstants.MessageHub.Global)]
        public async Task SendGlobalMessage(string nick, string message)
        {
            Console.WriteLine($"We found those parameter: {nick}, {message}");
            await Clients.All.SendAsync(HubConstants.MessageHub.Global, nick, message);
        }
        
        [HubMethodName(HubConstants.MessageHub.Channel)]
        public async Task SendChannelMessage(string nick, string channel, string message)
        {
            Console.WriteLine($"We found those parameter: {nick}, {message}");
            await Clients.Groups(channel).SendAsync(HubConstants.MessageHub.Channel, nick, message));
        }
        
        [HubMethodName(HubConstants.MessageHub.Private)]
        public async Task SendPrivateMessage(string nick, string receiver, string message)
        {
            Console.WriteLine($"We found those parameter: {nick}, {message}");
            await Clients.All.SendAsync(HubConstants.MessageHub.Private, nick, message);
        }
    }
}
