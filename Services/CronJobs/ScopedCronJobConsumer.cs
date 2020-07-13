using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TCGCollectionApp.Services {
    public class ScopedCronJobConsumer : BackgroundService {
        private readonly ILogger<ScopedCronJobConsumer> _logger;

        public ScopedCronJobConsumer(IServiceProvider services,
            ILogger<ScopedCronJobConsumer> logger) {
            Services = services;
            _logger = logger;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            Console.WriteLine("Consume Scoped Service Hosted Service running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken) {
            Console.WriteLine(this.ToString()+" is working.");

            using (var scope = Services.CreateScope()) {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IScopedCronJob>();

                await scopedProcessingService.DoWork(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken) {
            Console.WriteLine("Consume Scoped Service Hosted Service is stopping.");

            await Task.CompletedTask;
        }
    }
}
