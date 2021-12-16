using System;

namespace Common.Model.Exceptions
{
    public class AzureMessageProcessorException : Exception
    {
        private Exception ex;

        public AzureMessageProcessorException(Exception ex)
        {
            this.ex = ex;
        }
    }
}