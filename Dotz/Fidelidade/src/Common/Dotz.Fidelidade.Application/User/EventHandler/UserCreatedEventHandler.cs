using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Domain.Entities;
using Dotz.Fidelidade.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.User.EventHandler
{
    public class UserCreatedEventHandler : INotificationHandler<DomainEventNotification<UserCreatedEvent>>
    {
        private readonly IApplicationDbContext _context;

        public UserCreatedEventHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DomainEventNotification<UserCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            if (domainEvent.User != null)
            {
                WalletEntity wallet = new WalletEntity(domainEvent.User);
                await _context.Wallets.AddAsync(wallet);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
