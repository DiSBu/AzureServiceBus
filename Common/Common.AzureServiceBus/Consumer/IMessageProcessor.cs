namespace Common.AzureServiceBus.Consumer
{
    public interface IMessageProcessor<T>
    {
        void ProcessMessage(T msg);
    }
}