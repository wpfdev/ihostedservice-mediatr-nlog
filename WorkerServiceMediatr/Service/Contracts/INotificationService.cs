using System.Threading.Tasks;

namespace WorkerServiceMediatr.Service.Contracts
{
    public interface INotificationService
    {
        Task Notify(string notifyText);
    }
    
}
