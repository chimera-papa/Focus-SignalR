using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

namespace ClientSide
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = ServiceBuilder.Build();

            var chat = provider.GetService<IChat>();

            var url = "https://localhost:5001/Chat";

            var connection = new HubConnectionBuilder().WithUrl(url).Build();

            MessageReceiver.RegisterHandler(connection);

            chat.ConnectTo(connection).GetAwaiter().GetResult();
        }
    }
}