using MediatR;
using System.Threading.Tasks;
using WorkerServiceMediatr.Model;
using WorkerServiceMediatr.Service.Contracts;

namespace WorkerServiceMediatr.Service
{
    public class NotificationService : INotificationService
    {
        private readonly IMediator _mediator;

        public NotificationService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Notify(string notifyText)
        {
            await _mediator.Publish(new NotificationMessage { NotifyText = notifyText });
        }
    }
}
