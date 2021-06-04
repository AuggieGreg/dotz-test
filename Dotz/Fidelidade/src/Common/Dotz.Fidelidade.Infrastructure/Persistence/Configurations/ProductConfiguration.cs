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
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(k => k.ProductId);
            builder.Property(p => p.ProductId).ValueGeneratedNever();

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Price)
                .HasPrecision(10)
                .IsRequired();

            builder.Property(t => t.PartnerId)
                .IsRequired();

            builder.Property(t => t.CategoryId)
                .IsRequired();

            builder.HasOne(k => k.Category);
        }
    }
}
