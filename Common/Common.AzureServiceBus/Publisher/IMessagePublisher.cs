using System;
using System.Threading.Tasks;

namespace Common.AzureServiceBus
{
    public interface IMessagePublisher
    {
        Task SendAsync<T>(T obj);
        Task ScheduleMessageAsync<T>(T obj, DateTimeOffset dateTimeOffset);
    }
}