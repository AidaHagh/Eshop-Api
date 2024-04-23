using MediatR;

namespace Common.Domain
{
    public class BaseDomainEvent : INotification
    {
        public DateTime CreationDate { get; protected set; }
        public BaseDomainEvent()
        {
            CreationDate = new DateTime();
        }
    }
}
