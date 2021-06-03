using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Dto;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UserAddress.Commands.Update
{
    public class UpdateUserAddressCommand : IRequestWrapper<UserAddressDto>
    {
        public Guid AddressId { get; set; }

        public string PostalCode { get; set; }

        public string Address { get; set; }

        public int? Number { get; set; }

        public string Complement { get; set; }

        public bool IsMain { get; set; }
    }

    public class UpdateUserAddressCommandHandler : IRequestHandlerWrapper<UpdateUserAddressCommand, UserAddressDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public UpdateUserAddressCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<ServiceResult<UserAddressDto>> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(x => x.UserAddresses)
                .SingleAsync(s => s.UserId == _currentUserService.UserId, cancellationToken);

            var addressEntity = user.AddOrUpdateAddress(request.AddressId, request.PostalCode, request.Address, request.Number, request.Complement, request.IsMain, _currentUserService.UserId);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<UserAddressDto>(addressEntity));
        }
    }
}
