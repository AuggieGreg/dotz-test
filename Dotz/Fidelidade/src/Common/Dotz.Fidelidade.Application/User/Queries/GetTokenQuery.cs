using System;
using System.Threading;
using System.Threading.Tasks;
using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Dto;

namespace Dotz.Fidelidade.Application.ApplicationUser.Queries.GetToken
{
    public class GetTokenQuery : IRequestWrapper<LoginResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class GetTokenQueryHandler : IRequestHandlerWrapper<GetTokenQuery, LoginResponse>
    {
        private readonly ITokenService _tokenService;

        public GetTokenQueryHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<ServiceResult<LoginResponse>> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var user = new UserDto();
            user.UserId = Guid.NewGuid();
            user.Name = "change me";
            user.Role = "adm";

            if (user == null)
                return ServiceResult.Failed<LoginResponse>(ServiceError.ForbiddenError);


            return ServiceResult.Success(new LoginResponse
            {
                User = user,
                Token = _tokenService.GenerateToken(user.UserId.ToString(), user.Role)
            });
        }

    }
}
