using System;
using System.IO;
using System.Reflection;
using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ServerSide.Hubs;
using ServerSide.Service;

namespace ServerSide
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSignalR()
                .AddStackExchangeRedis(Configuration["redisUrl"], options =>
                {
                    options.Configuration.AbortOnConnectFail = false;
                    options.Configuration.AllowAdmin = true;
                    options.Configuration.ConnectRetry = 5;
                    options.Configuration.ResolveDns = true;
                })
                .AddMessagePackProtocol();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "title",
                    Description = "description"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddMvc();
            services.AddScoped<NotificationService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "V1 API"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MessageHub>($"/{HubConstants.MessageHub.Name}");
                endpoints.MapHub<NotificationHub>($"/{HubConstants.NotificationHub.Name}");
                endpoints.MapControllers();
            });
        }
    }
}
