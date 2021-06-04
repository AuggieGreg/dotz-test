using Dotz.Fidelidade.Domain.Common;
using Dotz.Fidelidade.Domain.Enums;
using Dotz.Fidelidade.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class WalletEntity : AuditableEntity
    {
        private readonly IWalletLoaderService _walletLoaderService;
        public WalletEntity(Guid walletId, IList<WalletTransactionEntity> transactions, IWalletLoaderService walletLoaderService)
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
                return Transactions.Sum(s => s.Amount);
            }
            private set {}
        }

        public WalletTransactionEntity ExchangeNewProduct(Guid productId)
        {
            var product = _walletLoaderService.LoadProduct(productId);
            var walletTransaction = new WalletTransactionEntity(product, this);

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
