using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Dto
{
    public class UserAddressDto
    {
        public Guid? AddressId { get; set; }

        public string PostalCode { get; set; }

        public string Address { get; set; }

        public int? Number { get; set; }

        public string Complement { get; set; }

        public bool IsMain { get; set; }

        public Guid? UserId { get; set; }
    }
}
