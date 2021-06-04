using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Dto
{
    public class WalletTransactionDto
    {
        public Guid WalletTransactionId { get; set; }

        public Guid WalletId { get; set; }

        public decimal TotalAmount { get; set; }

        public ProductExchangeDto ProductExchange { get; set; }

        public PartnerCreditDto PartnerCreditEntity { get; set; }
    }
}
