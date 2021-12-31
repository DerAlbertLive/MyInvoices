using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Terminal.Gui;

namespace Invoices.App
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildHost(args).Build().Run();
        }

        static IHostBuilder BuildHost(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddOptions<ConsoleLifetimeOptions>()
                        .Configure(o =>
                        {
                            o.SuppressStatusMessages = true;
                        });
                    services.AddHostedService<Worker>();
                });
        }
    }

    internal class Worker : IHostedService
    {
        readonly IHostApplicationLifetime _lifetime;
        readonly IServiceScopeFactory _scopeFactory;

        public Worker(IHostApplicationLifetime lifetime, IServiceScopeFactory scopeFactory)
        {
            _lifetime = lifetime;
            _scopeFactory = scopeFactory;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var app = ActivatorUtilities.CreateInstance<InvoicesApp>(scope.ServiceProvider);
                Application.Run(app);
//                Application.Run<>();
            }
            _lifetime.StopApplication();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;



        }
    }



}
