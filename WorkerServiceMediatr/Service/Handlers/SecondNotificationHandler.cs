using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using WorkerServiceMediatr.Model;

namespace WorkerServiceMediatr.Service.Handlers
{

    public class SecondNotificationHandler : INotificationHandler<NotificationMessage>
    {
        private readonly ILogger<SecondNotificationHandler> _logger;
       
        public SecondNotificationHandler(ILogger<SecondNotificationHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Debug from {this.GetType().Name}. Message  : {notification.NotifyText} ");
            return Task.CompletedTask;
        }
    }
}
