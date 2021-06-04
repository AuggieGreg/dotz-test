using Dotz.Fidelidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotz.Fidelidade.Infrastructure.Persistence.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<WalletEntity>
    {
        public void Configure(EntityTypeBuilder<WalletEntity> builder)
        {
            builder.HasKey(x => x.WalletId);
            builder.Property(p => p.WalletId).ValueGeneratedNever();

            builder.HasMany(k => k.Transactions);

            builder.HasOne(k => k.User).WithOne().HasForeignKey<WalletEntity>(w => w.WalletId);
        }
    }
}
