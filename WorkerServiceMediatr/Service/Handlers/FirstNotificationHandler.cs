using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using WorkerServiceMediatr.Model;

namespace WorkerServiceMediatr.Service.Handlers
{

    public class FirstNotificationHandler : INotificationHandler<NotificationMessage>
    {
        private readonly ILogger<FirstNotificationHandler> _logger;

        public FirstNotificationHandler(ILogger<FirstNotificationHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Info from {this.GetType().Name}. Message  : {notification.NotifyText} ");
            return Task.CompletedTask;
        }
    }
}
