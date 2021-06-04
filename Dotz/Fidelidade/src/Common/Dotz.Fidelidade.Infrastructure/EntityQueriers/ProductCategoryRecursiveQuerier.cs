using Dotz.Fidelidade.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotz.Fidelidade.Infrastructure.EntityQueriers
{
    public class ProductCategoryRecursiveQuerier : IProductCategoryRecursiveQuerier
    {
        private readonly IApplicationDbContext _context;

        public ProductCategoryRecursiveQuerier(IApplicationDbContext context)
        {
            _context = context;
        }

        private void GetAllCategories(Guid parentCategoryId, List<Guid> allCategoryIds)
        {
            allCategoryIds.Add(parentCategoryId);

            foreach (var child in _context.ProductCategories.AsNoTracking().Where(x => x.ParentCategoryId == parentCategoryId).Select(s => s.ProductCategoryId).ToList())
            {
                GetAllCategories(child, allCategoryIds);
            }
        }

        public IEnumerable<Guid> GetAllCategoryIdsByParentId(Guid parentCategoryId)
        {
            List<Guid> allCategoryIds = new();
            GetAllCategories(parentCategoryId, allCategoryIds);

            return allCategoryIds;
        }
    }
}
