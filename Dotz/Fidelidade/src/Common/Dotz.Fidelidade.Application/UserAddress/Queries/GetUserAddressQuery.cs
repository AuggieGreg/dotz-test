using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Dto;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UserAddress.Queries
{
    public class GetUserAddressQuery : IRequestWrapper<UserAddressDto>
    {
        public Guid UserAddressId { get; set; }
    }

    public class GetUserAddressQueryHandler : IRequestHandlerWrapper<GetUserAddressQuery, UserAddressDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetUserAddressQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<UserAddressDto>> Handle(GetUserAddressQuery request, CancellationToken cancellationToken)
        {
            var userAddress = await _context.UserAddresses.SingleOrDefaultAsync(x => x.AddressId == request.UserAddressId && x.UserId == _currentUserService.UserId);

            if (userAddress == null)
                return ServiceResult.Failed<UserAddressDto>(ServiceError.UserAddressNotFound);

            return ServiceResult.Success(_mapper.Map<UserAddressDto>(userAddress));
        }
    }
}
