namespace ZA365Solutions.Platform.Messaging
{
    using System;

    public interface IIntegrationEvent : IEvent, IMessage
    {
        string SystemId { get; set; }

        string SystemName { get; set; }
    }
}

