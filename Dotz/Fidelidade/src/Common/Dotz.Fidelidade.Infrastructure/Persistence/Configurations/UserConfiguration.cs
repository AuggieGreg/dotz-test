using Dotz.Fidelidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotz.Fidelidade.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(k => k.UserId);
            builder.Property(p => p.UserId).ValueGeneratedNever();

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Role)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.PasswordHash)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(t => t.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.IsActive)
                .IsRequired();

            builder.HasMany(k => k.UserAddresses);
        }
    }
}
