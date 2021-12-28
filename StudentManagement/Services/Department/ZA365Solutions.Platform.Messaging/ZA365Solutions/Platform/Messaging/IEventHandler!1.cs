namespace ZA365Solutions.Platform.Messaging
{
    using System;
    using System.Threading.Tasks;

    public interface IEventHandler<T> where T : IEvent
    {
        string HandlerName { get; }

        Task HandleAsync(T @event);
    }
}

