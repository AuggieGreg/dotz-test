using System.Threading;
using System.Threading.Tasks;
using Dotz.Fidelidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotz.Fidelidade.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<UserEntity> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
