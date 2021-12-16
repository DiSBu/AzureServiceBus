using System;

namespace Common.AzureServiceBus.Consumer
{
    public interface IMessageExceptionHandler<TMessage, TMessageProcessorException>
    {
        void HandleException<TMessageProcessorException>(Exception msg);
    }
}