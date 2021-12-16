namespace Common.AzureServiceBus.Consumer
{
    public abstract class MessageProcessor<T> : IMessageProcessor<T>
    {
        public abstract void ProcessMessage(T msg);
    }
}