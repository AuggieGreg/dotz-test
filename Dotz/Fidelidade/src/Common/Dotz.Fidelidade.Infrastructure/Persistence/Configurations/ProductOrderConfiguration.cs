using Dotz.Fidelidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotz.Fidelidade.Infrastructure.Persistence.Configurations
{
    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrderEntity>
    {
        public void Configure(EntityTypeBuilder<ProductOrderEntity> builder)
        {
            builder.Ignore(i => i.DeliveryStatusEnum);
            builder.HasKey(k=> k.ProductOrderId);
            builder.Property(k=> k.ProductOrderId).ValueGeneratedNever();

            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.ProductExchangeId).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.DeliveryStatus).HasMaxLength(20).IsRequired();
        }
    }
}
