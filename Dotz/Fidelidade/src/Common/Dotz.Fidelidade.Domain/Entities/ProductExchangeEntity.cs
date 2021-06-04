using Dotz.Fidelidade.Domain.Common;
using Dotz.Fidelidade.Domain.Interfaces;
using System;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class ProductExchangeEntity : AuditableEntity
    {
        public ProductExchangeEntity()
        {

        }

        public ProductExchangeEntity(Guid productId, ProductEntity product, WalletTransactionEntity transaction)
        {
            WalletTransactionId = transaction.WalletTransactionId;
            ProductId = productId;
            Product = product;
            Transaction = transaction;
        }

        public Guid WalletTransactionId { get; set; }

        public Guid ProductId { get; set; }

        public ProductEntity Product { get; set; }

        public WalletTransactionEntity Transaction { get; set; }
    }
}
