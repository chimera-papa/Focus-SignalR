using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientLib
{
    public class MessageSender : IMessageSender
    {
        private readonly string _nick;

        public MessageSender(string nick)
        {
            _nick = nick;
        }

        public Task SendToGlobalAsync(HubConnection connection, string message)
        {
            var dto = new GlobalMessageDto { Sender = _nick, Message = message };
            return connection.SendAsync(HubConstants.MessageHub.Global, dto);
        }

        public Task SendToChannelAsync(HubConnection connection, string channel, string message)
        {
            var dto = new ChannelMessageDto { Sender = _nick, Channel = channel, Message = message };
            return connection.SendAsync(HubConstants.MessageHub.Channel, dto);
        }

        public Task SendToPrivateAsync(HubConnection connection, string receivingUser, string message)
        {
            var dto = new PrivateMessageDto { Sender = _nick, Receiver = receivingUser, Message = message };
            return connection.SendAsync(HubConstants.MessageHub.Private, dto);
        }
    }
}