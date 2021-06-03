using Dotz.Fidelidade.Application.Common.Exceptions;
using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UserAddress.Commands.Delete
{
    public class DeleteUserAddressCommand : IRequestWrapper<DeleteUserAddressResponse>
    {
        public Guid Id { get; set; }
    }

    public class DeleteUserAddressCommandHandler : IRequestHandlerWrapper<DeleteUserAddressCommand, DeleteUserAddressResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteUserAddressCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<ServiceResult<DeleteUserAddressResponse>> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
        {
            var userAddress = await _context.UserAddresses.SingleOrDefaultAsync(x => x.AddressId == request.Id && x.UserId == _currentUserService.UserId);

            if (userAddress == null)
            {
                throw new NotFoundException(nameof(UserAddressEntity), request.Id);
            }

            _context.UserAddresses.Remove(userAddress);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(new DeleteUserAddressResponse());
        }
    }
}
