using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Dotz.Fidelidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dotz.Fidelidade.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<UserAddressEntity> UserAddresses { get; set; }
        public DbSet<PartnerCreditEntity> PartnerCredits { get; set; }
        public DbSet<ProductExchangeEntity> ProductExchanges { get; set; }
        public DbSet<WalletEntity> Wallets { get; set; }
        public DbSet<WalletTransactionEntity> WalletTransactions { get; set; }
        public DbSet<ProductOrderEntity> ProductOrders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        EntityEntry Entry([NotNullAttribute] object entity);

        EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
    }
}
