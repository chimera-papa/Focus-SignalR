using System;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.SignalR;

namespace ServerSide.Hubs
{
    public class MessageHub : Hub
    {
        [HubMethodName(HubConstants.MessageHub.Global)]
        public async Task SendGlobalMessage(GlobalMessageDto dto)
        {
            Console.WriteLine($"We found those parameter: {dto.Sender}, {dto.Message}");
            await Clients.All.SendAsync(HubConstants.MessageHub.Global, dto);
        }

        [HubMethodName(HubConstants.MessageHub.Channel)]
        public async Task SendChannelMessage(ChannelMessageDto dto)
        {
            Console.WriteLine($"We found those parameter: {dto.Sender}, {dto.Channel}, {dto.Message}");
            await Clients.Groups(dto.Channel).SendAsync(HubConstants.MessageHub.Channel, dto);
        }
        
        [HubMethodName(HubConstants.MessageHub.Private)]
        public async Task SendPrivateMessage(PrivateMessageDto dto)
        {
            Console.WriteLine($"We found those parameter: {dto.Sender}, {dto.Receiver}, {dto.Message}");
            await Clients.All.SendAsync(HubConstants.MessageHub.Private, dto);
        }
    }
}