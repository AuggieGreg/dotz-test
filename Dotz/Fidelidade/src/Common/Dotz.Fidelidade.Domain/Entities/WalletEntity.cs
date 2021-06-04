using Dotz.Fidelidade.Domain.Common;
using Dotz.Fidelidade.Domain.Enums;
using Dotz.Fidelidade.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class WalletEntity : AuditableEntity
    {
        public WalletEntity()
        {
            WalletTransactions = new List<WalletTransactionEntity>();
        }

        public WalletEntity(Guid walletId, IList<WalletTransactionEntity> transactions) : this()
        {
            WalletId = walletId;
            WalletTransactions = transactions;
        }

        public Guid WalletId { get; set; }

        public IList<WalletTransactionEntity> WalletTransactions { get; set; }

        public decimal Balance
        {
            get
            {
                return WalletTransactions.Sum(s => s.TotalAmount);
            }
            private set {}
        }

        public UserEntity User { get; set; }

        public WalletTransactionEntity ExchangeNewProduct(ProductEntity product, int quantity)
        {
            var walletTransaction = new WalletTransactionEntity(product, quantity, this);

            WalletTransactions.Add(walletTransaction);

            return walletTransaction;
        }

        public WalletTransactionEntity AddPartnerCredit(Guid partnerId, string description, decimal amount)
        {
            WalletTransactionEntity walletTransaction = new WalletTransactionEntity(amount, TransactionType.Entry, partnerId, description, this);

            WalletTransactions.Add(walletTransaction);

            return walletTransaction;
        }
    }
}
