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
    public class PartnerCreditConfiguration : IEntityTypeConfiguration<PartnerCreditEntity>
    {
        public void Configure(EntityTypeBuilder<PartnerCreditEntity> builder)
        {
            builder.HasKey(k => k.PartnerCreditId);
            builder.Property(p => p.PartnerCreditId).ValueGeneratedNever();

            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();

            builder.Property(p => p.PartnerId).IsRequired();

            builder.HasOne(k => k.WalletTransaction);
        }
    }
}
