namespace ZA365Solutions.Platform.Messaging
{
    using System;

    public interface IEvent<T> : IEvent, IMessage where T : IEventData
    {
        T EventData { get; set; }
    }
}

