using Dotz.Fidelidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotz.Fidelidade.Infrastructure.Persistence.Configurations
{
    public class ProductExchangeConfiguration : IEntityTypeConfiguration<ProductExchangeEntity>
    {
        public void Configure(EntityTypeBuilder<ProductExchangeEntity> builder)
        {
            builder.Ignore(i => i.DomainEvents);

            builder.HasKey(k => k.ProductExchangeId);
            builder.Property(p => p.ProductExchangeId).ValueGeneratedNever();

            builder.Property(p => p.Price).HasPrecision(10).IsRequired();

            builder.Property(p => p.Quantity).HasPrecision(5).IsRequired();

            builder.Property(p => p.ProductId).IsRequired();

            builder.HasOne(k => k.Product);

            builder.HasOne(k => k.WalletTransaction);
        }
    }
}
