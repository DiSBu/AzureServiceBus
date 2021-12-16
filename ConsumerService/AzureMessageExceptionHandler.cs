using Common.AzureServiceBus.Consumer;
using Common.Model.Exceptions;
using Common.Model.MessageModels;
using Microsoft.Extensions.Logging;
using System;

namespace ConsumerService
{
    public class AzureMessageExceptionHandler : MessageExceptionHandler<AzureMessage, AzureMessageProcessorException>
    {
        public AzureMessageExceptionHandler(ILogger<AzureMessageExceptionHandler> logger)
        {
        }

        public override void HandleException<TMessageProcessorException>(Exception ex)
        {          
        }
    }
}