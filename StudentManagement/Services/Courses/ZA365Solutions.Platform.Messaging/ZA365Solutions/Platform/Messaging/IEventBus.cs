namespace ZA365Solutions.Platform.Messaging
{
    using System;
    using System.Threading.Tasks;

    public interface IEventBus
    {
        Task Publish(IIntegrationEvent @event);

        Task Subscribe<T, TH>()
          where T : IIntegrationEvent
          where TH : IIntegrationEventHandler<T>;

        Task Unsubscribe<T, TH>()
          where T : IIntegrationEvent
          where TH : IIntegrationEventHandler<T>;

        Task SubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler;

        Task UnsubscribeDynamic<TH>(string eventName) where TH : IDynamicIntegrationEventHandler;
    }
}

