using Dotz.Fidelidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Dto
{
    public class WalletDto
    {
        public Guid WalletId { get; set; }

        public IList<WalletTransactionDto> WalletTransactions { get; set; }

        public decimal Balance { get; set; }
    }
}
