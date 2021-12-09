using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace ClientSide
{
    public class MessageSender : ISender
    {
        private readonly string _nick;

        private const string callerMethodName = "SendMessageInChat";

        public MessageSender(string nick)
        {
            _nick = nick;
        }

        public Task SendMessageAsync(HubConnection connection, string message)
        {
            var arguments = new[] { _nick, message };
            return connection.InvokeCoreAsync(callerMethodName, arguments);
        }
    }

    public interface ISender
    {
        Task SendMessageAsync(HubConnection connection, string message);
    }
}
