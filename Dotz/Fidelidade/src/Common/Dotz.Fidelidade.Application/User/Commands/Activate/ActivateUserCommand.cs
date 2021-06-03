using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.User.Commands.Activate
{
    public class ActivateUserCommand : IRequestWrapper<ActivateUserResponse>
    {
        public string SecretCode { get; set; }
    }

    public class ActivateUserCommandHandler : IRequestHandlerWrapper<ActivateUserCommand, ActivateUserResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUserActivationService _userActivation;
        public ActivateUserCommandHandler(IApplicationDbContext context, IUserActivationService userActivation)
        {
            _context = context;
            _userActivation = userActivation;
        }

        public async Task<ServiceResult<ActivateUserResponse>> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            var userId = _userActivation.GetUserIdFromCode(request.SecretCode);

            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId && x.IsActive == false, cancellationToken);

            if (user == null)
                return ServiceResult.Failed<ActivateUserResponse>(ServiceError.UserNotFound);

            user.IsActive = true;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(new ActivateUserResponse());
        }
    }
}