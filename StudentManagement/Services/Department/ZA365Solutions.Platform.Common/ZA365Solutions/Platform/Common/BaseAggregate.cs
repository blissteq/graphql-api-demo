namespace ZA365Solutions.Platform.Common
{
    using System;
    using System.Collections.Generic;
    using ZA365Solutions.Platform.Messaging;

    public abstract class BaseAggregate<T> : IAggregate<T> where T : IAggregateRoot
    {
        private readonly IDictionary<Type, IEvent> _events = (IDictionary<Type, IEvent>)new Dictionary<Type, IEvent>();
        protected T entity;

        public BaseAggregate(T entity) => this.entity = entity;

        public T Entity => this.entity;

        public Guid Id => this.entity.Id;

        public IEnumerable<IEvent> Events => (IEnumerable<IEvent>)this._events.Values;

        public void AddEvent(IEvent domainEvent) => this._events[((object)domainEvent).GetType()] = domainEvent;

        public void ClearEvents() => ((ICollection<KeyValuePair<Type, IEvent>>)this._events).Clear();
    }

}

