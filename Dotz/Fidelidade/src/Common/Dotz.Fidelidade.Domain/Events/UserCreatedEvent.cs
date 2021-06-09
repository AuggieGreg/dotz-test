using Dotz.Fidelidade.Domain.Common;
using Dotz.Fidelidade.Domain.Entities;

namespace Dotz.Fidelidade.Domain.Events
{
    public class UserCreatedEvent : DomainEvent
    {
        public UserCreatedEvent(UserEntity user)
        {
            User = user;
        }

        public UserEntity User { get; }
    }
}
