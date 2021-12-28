namespace ZA365Solutions.Platform.Common
{
    using System;
    using System.Collections.Generic;
    using ZA365Solutions.Platform.Messaging;

    public interface IAggregate<T> where T : IAggregateRoot
    {
        T Entity { get; }

        IEnumerable<IEvent> Events { get; }

        void AddEvent(IEvent domainEvent);

        void ClearEvents();
    }
}

