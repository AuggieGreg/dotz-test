using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UserAddress.Queries
{
    public class GetAllUserAddressQuery : IRequestWrapper<List<UserAddressDto>>
    {
    }

    public class GetAllUserAddressQueryHandler : IRequestHandlerWrapper<GetAllUserAddressQuery, List<UserAddressDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetAllUserAddressQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<UserAddressDto>>> Handle(GetAllUserAddressQuery request, CancellationToken cancellationToken)
        {
            var allAddresses = await _context.UserAddresses
                .Where(x => x.UserId == _currentUserService.UserId)
                .ProjectToType<UserAddressDto>(_mapper.Config)
                .ToListAsync();

            return ServiceResult.Success(allAddresses);
        }
    }
}
