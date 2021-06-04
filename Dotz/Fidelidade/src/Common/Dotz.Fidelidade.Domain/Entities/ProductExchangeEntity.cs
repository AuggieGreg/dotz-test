using Dotz.Fidelidade.Domain.Common;
using Dotz.Fidelidade.Domain.Events;
using System;
using System.Collections.Generic;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class ProductExchangeEntity : AuditableEntity, IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }

        public ProductExchangeEntity()
        {
            DomainEvents = new List<DomainEvent>();
        }

        public ProductExchangeEntity(int quantity, ProductEntity product, WalletTransactionEntity walletTransaction) : this()
        {
            ProductExchangeId = walletTransaction.WalletTransactionId;
            ProductId = product.ProductId;
            Product = product;
            Quantity = quantity;
            Price = product.Price;
            WalletTransaction = walletTransaction;
            DomainEvents.Add(new ProductExchangedEvent(this));
        }

        public Guid ProductExchangeId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public ProductEntity Product { get; set; }

        public WalletTransactionEntity WalletTransaction { get; set; }
    }
}
