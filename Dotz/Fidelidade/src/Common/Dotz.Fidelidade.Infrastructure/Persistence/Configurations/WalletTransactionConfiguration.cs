using Dotz.Fidelidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotz.Fidelidade.Infrastructure.Persistence.Configurations
{
    public class WalletTransactionConfiguration : IEntityTypeConfiguration<WalletTransactionEntity>
    {
        public void Configure(EntityTypeBuilder<WalletTransactionEntity> builder)
        {
            builder.Ignore(p => p.TransactionTypeEnum);

            builder.HasKey(k => k.WalletTransactionId);
            builder.Property(p => p.WalletTransactionId)
                .ValueGeneratedNever();

            builder.Property(p => p.WalletId)
                .IsRequired();

            builder.Property(p => p.TransactionType).HasMaxLength(20).IsRequired();
            builder.Property(p => p.TotalAmount).HasPrecision(10, 0).IsRequired();

            builder.HasOne(k => k.ProductExchange).WithOne().HasForeignKey<ProductExchangeEntity>(f => f.ProductExchangeId);
            builder.HasOne(k => k.PartnerCreditEntity).WithOne().HasForeignKey<PartnerCreditEntity>(f => f.PartnerCreditId);

            builder.HasOne(k => k.Wallet);
        }
    }
}
