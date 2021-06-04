using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Domain.Entities;
using Dotz.Fidelidade.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Infrastructure.Persistence.BoundedContexts
{
    public class WalletBoundedContext : IWalletBoundedContext
    {
        private readonly IApplicationDbContext _context;

        public WalletBoundedContext(IApplicationDbContext context)
        {
            this._context = context;
        }
        public IQueryable<WalletEntity> Wallets => _context.Wallets
                .Include(i => i.WalletTransactions).ThenInclude(i => i.ProductExchange)
                .Include(i => i.WalletTransactions).ThenInclude(i => i.ProductExchange).ThenInclude(i => i.Product).ThenInclude(i => i.Category)
                .Include(i => i.WalletTransactions).ThenInclude(i => i.PartnerCreditEntity);
    }
}
