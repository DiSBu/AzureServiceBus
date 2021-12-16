using System.Threading;
using System.Threading.Tasks;

namespace Common.Services
{
    public interface IPublisherService
    {
        void Dispose();
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
        void Process(object state);
    }
}