using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Common.Security;
using Dotz.Fidelidade.Application.Dto;
using Dotz.Fidelidade.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UserAddress.Commands.Create
{
    [Authorize(Roles = "User")]
    public class CreateUserAddressCommand : IRequestWrapper<UserAddressDto>
    {
        public string PostalCode { get; set; }

        public string Address { get; set; }

        public int? Number { get; set; }

        public string Complement { get; set; }

        public bool IsMain { get; set; }
    }

    public class CreateUserAddressCommandHandler : IRequestHandlerWrapper<CreateUserAddressCommand, UserAddressDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateUserAddressCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<ServiceResult<UserAddressDto>> Handle(CreateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(x => x.UserAddresses)
                .SingleAsync(s => s.UserId == _currentUserService.UserId, cancellationToken);

            var addressEntity = user.AddOrUpdateAddress(Guid.NewGuid(), request.PostalCode, request.Address, request.Number, request.Complement, request.IsMain);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<UserAddressDto>(addressEntity));
        }
    }
}
