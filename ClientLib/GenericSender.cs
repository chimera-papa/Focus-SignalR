using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace ClientLib
{
    public static class GenericSender
    {
        public static Task SendAsync(this HubConnection connection, string methodName, object dto)
        {
            return connection.InvokeAsync(methodName, dto);
        }
    }
}