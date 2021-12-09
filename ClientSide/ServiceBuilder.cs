using Microsoft.Extensions.DependencyInjection;
using System;
using ClientLib;

namespace ClientSide
{
    public static class ServiceBuilder
    {
        public static ServiceProvider Build()
        {
            var service = new ServiceCollection();

            Console.WriteLine("Choose a nick: ");
            var nick = Console.ReadLine();

            service
                .AddSingleton<IMessageSender>(_ => new MessageSender(nick!))
                .AddSingleton<INotification, Notification>()
                .AddSingleton<IChat, PublicChat>();

            return service.BuildServiceProvider();
        }
    }
}