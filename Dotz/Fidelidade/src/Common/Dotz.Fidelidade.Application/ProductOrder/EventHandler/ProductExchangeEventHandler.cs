using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Domain.Entities;
using Dotz.Fidelidade.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.ProductOrder.EventHandler
{
    public class ProductExchangeEventHandler : INotificationHandler<DomainEventNotification<ProductExchangedEvent>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public ProductExchangeEventHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DomainEventNotification<ProductExchangedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            if (domainEvent.ProductExchange != null)
            {
                var productOrder = new ProductOrderEntity(notification.DomainEvent.ProductExchange);
                await _context.ProductOrders.AddAsync(productOrder);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
