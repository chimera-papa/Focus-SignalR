using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientLib
{
    public interface IMessageSender
    {
        Task SendToGlobalAsync(HubConnection connection, string message);
        Task SendToChannelAsync(HubConnection connection, string channel, string message);
        Task SendToPrivateAsync(HubConnection connection, string receivingUser, string message);
    }
}