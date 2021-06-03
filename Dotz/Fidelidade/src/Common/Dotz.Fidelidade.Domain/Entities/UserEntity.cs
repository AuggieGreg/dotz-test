using Dotz.Fidelidade.Domain.Common;
using System;
using System.Collections.Generic;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class UserEntity : AuditableEntity
    {
        public UserEntity()
        {
            UserAddresses = new List<UserAddressEntity>();
        }

        public Guid? UserId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool? IsActive { get; set; }

        public IList<UserAddressEntity> UserAddresses { get; set; }
    }
}
