namespace ZA365Solutions.Platform.Common
{
    using System;

    public interface IAggregateRoot : IEntity
    {
        DateTime LastProcessedEventTime { get; }
    }
}

