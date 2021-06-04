using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Domain.Common;
using Dotz.Fidelidade.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dotz.Fidelidade.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext(
            DbContextOptions options,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService,
            IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
            _currentUserService = currentUserService;
            _domainEventService = domainEventService;
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories{ get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<UserAddressEntity> UserAddresses { get; set; }
        public DbSet<PartnerCreditEntity> PartnerCredits { get; set; }
        public DbSet<ProductExchangeEntity> ProductExchanges { get; set; }
        public DbSet<WalletEntity> Wallets { get; set; }
        public DbSet<WalletTransactionEntity> WalletTransactions { get; set; }
        public DbSet<ProductOrderEntity> ProductOrders { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Creator = _currentUserService.UserId.ToString();
                        entry.Entity.CreateDate = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modifier = _currentUserService.UserId.ToString();
                        entry.Entity.ModifyDate = _dateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents();

            return result;
        }

        private async Task DispatchEvents()
        {
            while (true)
            {
                var domainEventEntity = ChangeTracker
                    .Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .FirstOrDefault(domainEvent => !domainEvent.IsPublished);

                if (domainEventEntity == null) break;

                domainEventEntity.IsPublished = true;
                await _domainEventService.Publish(domainEventEntity);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
