using Dotz.Fidelidade.Domain.Common;
using System;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class ProductExchangeEntity : AuditableEntity
    {
        public ProductExchangeEntity()
        {

        }

        public ProductExchangeEntity(int quantity, ProductEntity product, WalletTransactionEntity walletTransaction)
        {
            ProductExchangeId = walletTransaction.WalletTransactionId;
            ProductId = product.ProductId;
            Product = product;
            Quantity = quantity;
            Price = product.Price;
            WalletTransaction = walletTransaction;
        }

        public Guid ProductExchangeId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public ProductEntity Product { get; set; }

        public WalletTransactionEntity WalletTransaction { get; set; }
    }
}
