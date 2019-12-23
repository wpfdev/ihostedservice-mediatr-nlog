using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorkerServiceMediatr.Service.Contracts;

namespace WorkerServiceMediatr
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly INotificationService notificationService;

        public Worker(ILogger<Worker> logger, INotificationService notificationService)
        {
            _logger = logger;
            this.notificationService = notificationService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    await notificationService.Notify("This is a test notification for all handlers");
                    await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on worker service");
            }
            
        }
    }
}
