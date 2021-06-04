using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Domain.Entities;
using Dotz.Fidelidade.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Infrastructure.EntityQueriers
{
    public class WalletLoaderService : IWalletLoaderService
    {
        private readonly IApplicationDbContext _context;
        public WalletLoaderService(IApplicationDbContext context)
        {
            _context = context;
        }

        public ProductEntity LoadProduct(Guid productId)
        {
            return _context.Products.Single(s => s.ProductId == productId);
        }
    }
}
