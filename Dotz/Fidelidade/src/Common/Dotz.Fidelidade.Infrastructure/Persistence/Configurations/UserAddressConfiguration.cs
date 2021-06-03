using Dotz.Fidelidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Infrastructure.Persistence.Configurations
{
    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddressEntity>
    {
        public void Configure(EntityTypeBuilder<UserAddressEntity> builder)
        {
            builder.ToTable("UserAddress");
            builder.HasKey(k => k.AddressId);
            builder.Property(p => p.AddressId)
                .ValueGeneratedNever();

            builder.Property(p => p.Address)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Complement)
                .HasMaxLength(200);

            builder.Property(p => p.IsMain)
                .IsRequired();

            builder.Property(p => p.UserId)
                .IsRequired();

            builder.HasOne(k => k.User);
        }
    }
}
