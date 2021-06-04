using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Dto
{
    public class PartnerCreditDto
    {
        public Guid PartnerCreditId { get; set; }

        public Guid PartnerId { get; set; }

        public string Description { get; set; }

    }
}
