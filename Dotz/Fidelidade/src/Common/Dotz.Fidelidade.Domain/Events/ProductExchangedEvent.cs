using Dotz.Fidelidade.Domain.Common;
using Dotz.Fidelidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
