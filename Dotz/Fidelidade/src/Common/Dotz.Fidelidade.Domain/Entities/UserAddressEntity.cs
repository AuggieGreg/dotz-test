using Dotz.Fidelidade.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class UserAddressEntity : AuditableEntity
    {
        public UserAddressEntity()
        {
        }

        public UserAddressEntity(Guid? addressId, string postalCode, string address, int? number, string complement, bool isMain, Guid? userId, UserEntity user)
        {
            AddressId = addressId;
            PostalCode = postalCode;
            Address = address;
            Number = number;
            Complement = complement;
            IsMain = isMain;
            UserId = userId;
            User = user;
        }

        public Guid? AddressId { get; set; }

        public string PostalCode { get; set; }

        public string Address { get; set; }

        public int? Number { get; set; }

        public string Complement { get; set; }

        public bool IsMain { get; set; }

        public Guid?  UserId { get; set; }

        public UserEntity User { get; set; }
    }
}
