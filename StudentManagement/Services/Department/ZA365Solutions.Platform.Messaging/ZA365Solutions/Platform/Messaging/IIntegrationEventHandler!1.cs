namespace ZA365Solutions.Platform.Messaging
{
    using System;
    using System.Threading.Tasks;

    public interface IIntegrationEventHandler<T> where T : IIntegrationEvent
    {
        string HandlerName { get; }

        Task HandleAsync(T @event);
    }
}

