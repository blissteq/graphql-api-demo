namespace ZA365Solutions.Platform.Messaging
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(object eventData);
    }
}

