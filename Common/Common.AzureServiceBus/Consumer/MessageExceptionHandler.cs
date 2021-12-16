using System;

namespace Common.AzureServiceBus.Consumer
{
    public abstract class MessageExceptionHandler<TMessage, TMessageProcessorException> : IMessageExceptionHandler<TMessage, TMessageProcessorException>
    {
        public abstract void HandleException<TMessageProcessorException>(Exception msg);
    }
}