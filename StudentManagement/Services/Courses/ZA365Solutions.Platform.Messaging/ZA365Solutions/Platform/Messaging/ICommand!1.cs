namespace ZA365Solutions.Platform.Messaging
{
    using System;

    public interface ICommand<T> : IMessage where T : ICommandData
    {
        string UserId { get; set; }

        Guid SubscriptionId { get; set; }

        string UserEmail { get; set; }

        DateTime CommandTime { get; set; }

        Guid CommandId { get; }

        T CommandData { get; set; }
    }
}

