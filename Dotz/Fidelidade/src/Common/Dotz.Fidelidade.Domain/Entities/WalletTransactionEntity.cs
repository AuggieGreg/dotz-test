using Dotz.Fidelidade.Domain.Common;
using Dotz.Fidelidade.Domain.Enums;
using System;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class WalletTransactionEntity : AuditableEntity
    {
        public WalletTransactionEntity(ProductEntity product, WalletEntity wallet)
        {
            WalletTransactionId = Guid.NewGuid();
            WalletId = wallet.WalletId;
            Amount = -product.Price;
            TransactionTypeEnum = Enums.TransactionType.Exchange;
            ProductExchange = new ProductExchangeEntity(product.ProductId, product, this);
            Wallet = wallet;
        }

        public WalletTransactionEntity(decimal amount, TransactionType transactionTypeEnum, Guid partnerId, string description, WalletEntity wallet)
        {
            WalletTransactionId = Guid.NewGuid();
            WalletId = wallet.WalletId;
            Amount = amount;
            TransactionTypeEnum = transactionTypeEnum;
            PartnerCreditEntity = new PartnerCreditEntity();
        }

        public Guid WalletTransactionId { get; set; }

        public Guid WalletId { get; set; }

        public decimal Amount { get; set; }

        public TransactionType TransactionTypeEnum 
        {   
            get
            {
                return Enum.Parse<TransactionType>(TransactionType);
            }
            set
            {
                TransactionType = value.ToString();
            }
        }
        public string TransactionType
        {
            get;
            private set;
        }


        public ProductExchangeEntity ProductExchange { get; set; }

        public PartnerCreditEntity PartnerCreditEntity { get; set; }

        public WalletEntity Wallet { get; set; }
    }
}
