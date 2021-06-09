using Dotz.Fidelidade.Domain.Common;
using Dotz.Fidelidade.Domain.Entities;

namespace Dotz.Fidelidade.Domain.Events
{
    public class ProductExchangedEvent : DomainEvent
    {
        public ProductExchangedEvent(ProductExchangeEntity productExchange)
        {
            ProductExchange = productExchange;
        }

        public ProductExchangeEntity ProductExchange { get; }
    }
}
