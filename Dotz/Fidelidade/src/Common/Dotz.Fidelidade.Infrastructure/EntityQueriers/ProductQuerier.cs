using Dotz.Fidelidade.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Infrastructure.EntityQueriers
{
    public class ProductQuerier : IProductQuerier
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ProductQuerier(IApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public async Task<bool> ExistsById(Guid productId, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Products.AnyAsync(x => x.ProductId == productId, cancellationToken);
        }
    }
}
