using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Mapping;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Product.Queries.GetAllProductsWithPagination
{
    public class GetAllProductsWithPaginationQuery : IRequestWrapper<PaginatedList<ProductDto>>
    {
        public Guid? CategoryId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetAllProductsWithPaginationQueryHandler : IRequestHandlerWrapper<GetAllProductsWithPaginationQuery, PaginatedList<ProductDto>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        private readonly IProductCategoryRecursiveQuerier _productCategoryRecursiveQuerier;
        public GetAllProductsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper, IProductCategoryRecursiveQuerier productCategoryRecursiveQuerier)
        {
            _context = context;
            _mapper = mapper;
            _productCategoryRecursiveQuerier = productCategoryRecursiveQuerier;
        }

        public async Task<ServiceResult<PaginatedList<ProductDto>>> Handle(GetAllProductsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Products.AsQueryable();

            if (request.CategoryId.HasValue)
            {
                var allCategoryIds = _productCategoryRecursiveQuerier.GetAllCategoryIdsByParentId(request.CategoryId.Value);
                query = query.Where(x => allCategoryIds.Contains(x.CategoryId));
            }

            PaginatedList<ProductDto> list = await query
                .OrderBy(o => o.Name)
                .ProjectToType<ProductDto>(_mapper.Config)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return ServiceResult.Success(list);
        }
    }
}
