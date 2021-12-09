using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace ClientSide
{
    static class Program
    {
        private static async Task Main(string[] args)
        {
            var provider = ServiceBuilder.Build();

            var chat = provider.GetService<IChat>();

            var url = $"https://localhost:5001/{HubConstants.MessageHub.Name}";

            var connection = new HubConnectionBuilder().AddMessagePackProtocol().WithUrl(url).Build();

            await chat.ConnectTo(connection);
        }
    }
}