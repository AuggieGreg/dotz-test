using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class WalletTransactionDto
    {
        public Guid WalletTransactionId { get; set; }

        public Guid WalletId { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
