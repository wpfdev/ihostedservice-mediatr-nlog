using MediatR;

namespace WorkerServiceMediatr.Model
{
    public class NotificationMessage : INotification
    {
        public string NotifyText { get; set; }
    }
}
