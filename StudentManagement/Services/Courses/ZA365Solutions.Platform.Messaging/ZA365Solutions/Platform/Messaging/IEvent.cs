namespace ZA365Solutions.Platform.Messaging
{
    using System;

    public interface IEvent : IMessage
    {
        Guid EventId { get; }

        DateTime EventTime { get; }
    }
}

