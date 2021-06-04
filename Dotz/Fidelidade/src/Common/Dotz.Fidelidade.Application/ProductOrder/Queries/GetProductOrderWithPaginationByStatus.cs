using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Mapping;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Common.Security;
using Dotz.Fidelidade.Application.Dto;
using Mapster;
using MapsterMapper;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.ProductOrder.Queries
{
    [Authorize(Roles = "User")]
    public class GetProductOrderWithPaginationByStatus : IRequestWrapper<PaginatedList<ProductOrderDto>>
    {
        public string DeliveryStatus { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetProductOrderByUserAndStatusHandler : IRequestHandlerWrapper<GetProductOrderWithPaginationByStatus, PaginatedList<ProductOrderDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetProductOrderByUserAndStatusHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<ServiceResult<PaginatedList<ProductOrderDto>>> Handle(GetProductOrderWithPaginationByStatus request, CancellationToken cancellationToken)
        {
            var productOrders = await _context.ProductOrders
                .Where(x => x.UserId == _currentUserService.UserId && x.DeliveryStatus == request.DeliveryStatus)
                .ProjectToType<ProductOrderDto>(_mapper.Config)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            return ServiceResult.Success(productOrders);
        }
    }
}
