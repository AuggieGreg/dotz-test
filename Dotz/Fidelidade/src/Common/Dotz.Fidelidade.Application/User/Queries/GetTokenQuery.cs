using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Dto;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

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
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IMapper _mapper;

        public GetTokenQueryHandler(ITokenService tokenService, IApplicationDbContext context, IPasswordHashService passwordHashService, IMapper mapper)
        {
            _tokenService = tokenService;
            _context = context;
            _passwordHashService = passwordHashService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<LoginResponse>> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            string hash = _passwordHashService.GetHash(request.Password);
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email && x.PasswordHash == hash);

            if (user == null)
                return ServiceResult.Failed<LoginResponse>(ServiceError.FailedLoginError);


            return ServiceResult.Success(new LoginResponse
            {
                User = _mapper.Map<UserDto>(user),
                Token = _tokenService.GenerateToken(user.UserId.ToString(), user.Role)
            });
        }

    }
}
