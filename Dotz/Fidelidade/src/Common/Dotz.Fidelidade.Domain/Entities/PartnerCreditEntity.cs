using Dotz.Fidelidade.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class PartnerCreditEntity : AuditableEntity
    {
        public Guid WalletTransactionId { get; set; }

        public Guid PartnerId { get; set; }

        public string Description { get; set; }

        public WalletTransactionEntity WalletTransaction { get; set; }
    }
}
