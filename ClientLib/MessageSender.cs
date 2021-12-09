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
            var dto = new MessageDto { Sender = _nick, Message = message };
            return connection.InvokeAsync(HubConstants.MessageHub.Global, dto);
        }

        public Task SendToChannelAsync(HubConnection connection, string channel, string message)
        {
            var arguments = new object[] {_nick, channel, message};
            return connection.InvokeCoreAsync(HubConstants.MessageHub.Channel, arguments);
        }

        public Task SendToPrivateAsync(HubConnection connection, string receivingUser, string message)
        {
            var arguments = new object[] {_nick, receivingUser, message};
            return connection.InvokeCoreAsync(HubConstants.MessageHub.Private, arguments);
        }
    }

    public interface IMessageSender
    {
        Task SendToGlobalAsync(HubConnection connection, string message);
        Task SendToChannelAsync(HubConnection connection, string channel, string message);
        Task SendToPrivateAsync(HubConnection connection, string receivingUser, string message);
    }
}