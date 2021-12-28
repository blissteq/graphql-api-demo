namespace ZA365Solutions.Platform.Messaging
{
    using System;
    using System.Threading.Tasks;

    public interface IEventHandler<T, Td>
        where T : IEvent<Td>
        where Td : IEventData
    {
        string HandlerName { get; }

        Task HandleAsync(T @event);
    }
}

