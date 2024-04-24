using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Domain
{
    public class AggregateRoot : BaseEntity
    {
        private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
        [NotMapped]
        public List<BaseDomainEvent> DomainEvents => _domainEvents;
        public void AddDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public void RemoveDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }
    }
}
