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
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            builder.HasKey(k => k.ProductCategoryId);
            builder.Property(p => p.ProductCategoryId).ValueGeneratedNever();

            builder.Property(p => p.Name)
                .HasMaxLength(100);

            builder.HasOne(k => k.ParentCategory);

            builder.HasMany(k => k.ChildCategories);
        }
    }
}
