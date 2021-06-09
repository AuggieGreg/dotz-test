using Dotz.Fidelidade.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class UserEntity : AuditableEntity, IHasDomainEvent
    {
        public UserEntity()
        {
            UserAddresses = new List<UserAddressEntity>();
            ProductOrders = new List<ProductOrderEntity>();
        }

        public UserEntity(string name, string role, string passwordHash, string email, DateTime? birthDate, bool? isActive) : this()
        {
            UserId = Guid.NewGuid();
            Name = name;
            Role = role;
            PasswordHash = passwordHash;
            Email = email;
            BirthDate = birthDate;
            IsActive = isActive;
            //create user event dispatch
        }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool? IsActive { get; set; }

        public WalletEntity Wallet { get; set; }

        public IList<UserAddressEntity> UserAddresses { get; private set; }

        public IList<ProductOrderEntity> ProductOrders { get; private set; }

        public UserAddressEntity AddOrUpdateAddress(Guid addressId, string postalCode, string address, int? number, string complement, bool isMain)
        {
            if (isMain)
            {
                this.UserAddresses.ToList().ForEach(x => x.IsMain = false);
            }

            var addOrUpdateAddress =  this.UserAddresses.SingleOrDefault(r => r.AddressId == addressId);

            if (addOrUpdateAddress == null)
            {
                addOrUpdateAddress = new(addressId, postalCode, address, number, complement, isMain, this);
                this.UserAddresses.Add(addOrUpdateAddress);
            }
            else 
            {
                addOrUpdateAddress.PostalCode = postalCode;
                addOrUpdateAddress.Address = address;
                addOrUpdateAddress.Number = number;
                addOrUpdateAddress.Complement = complement;
                addOrUpdateAddress.IsMain = isMain;
            }

            return addOrUpdateAddress;
        }
    }
}
