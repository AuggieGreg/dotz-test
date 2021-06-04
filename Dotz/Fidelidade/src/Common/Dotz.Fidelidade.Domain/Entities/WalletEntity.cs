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
        private readonly IWalletLoaderService _walletLoaderService;

        public WalletEntity()
        {
            Transactions = new List<WalletTransactionEntity>();
        }

        public WalletEntity(Guid walletId, IList<WalletTransactionEntity> transactions, IWalletLoaderService walletLoaderService) : this()
        {
            WalletId = walletId;
            Transactions = transactions;
            _walletLoaderService = walletLoaderService;
        }

        public Guid WalletId { get; set; }

        public IList<WalletTransactionEntity> Transactions { get; set; }

        public decimal Balance
        {
            get
            {
                return Transactions.Sum(s => s.TotalAmount);
            }
            private set {}
        }

        public UserEntity User { get; set; }

        public WalletTransactionEntity ExchangeNewProduct(Guid productId, int quantity)
        {
            var product = _walletLoaderService.LoadProduct(productId);
            var walletTransaction = new WalletTransactionEntity(product, quantity, this);

            Transactions.Add(walletTransaction);

            return walletTransaction;
        }

        public WalletTransactionEntity AddPartnerCredit(Guid partnerId, string description, decimal amount)
        {
            WalletTransactionEntity walletTransaction = new WalletTransactionEntity(amount, TransactionType.Entry, partnerId, description, this);

            Transactions.Add(walletTransaction);

            return walletTransaction;
        }
    }
}
