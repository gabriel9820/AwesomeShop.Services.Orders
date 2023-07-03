using AwesomeShop.Services.Orders.Core.Events;
using System.Collections.Generic;

namespace AwesomeShop.Services.Orders.Core.Entities
{
    public abstract class AggregateRoot : BaseEntity
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }
    }
}
