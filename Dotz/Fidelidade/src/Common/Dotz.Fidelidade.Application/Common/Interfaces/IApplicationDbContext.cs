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
        DbSet<UserEntity> Users { get; set; }

        DbSet<UserAddressEntity> UserAddresses{ get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        EntityEntry Entry([NotNullAttribute] object entity);

        EntityEntry<TEntity> Entry<TEntity>([NotNullAttribute] TEntity entity) where TEntity : class;
    }
}
