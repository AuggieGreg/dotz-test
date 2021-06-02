using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Dto;
using Dotz.Fidelidade.Domain.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.User.Commands.Create
{
    public class CreateUserCommand : IRequestWrapper<UserDto>
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandlerWrapper<CreateUserCommand, UserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHashService _passwordHashService;
        public CreateUserCommandHandler(IApplicationDbContext context, IMapper mapper, IPasswordHashService passwordHashService)
        {
            _context = context;
            _mapper = mapper;
            _passwordHashService = passwordHashService;
        }

        public async Task<ServiceResult<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserEntity
            {
                UserId = Guid.NewGuid(),
                Name = request.Name,
                BirthDate = request.BirthDate,
                Email = request.Email,
                Role = "User",
                PasswordHash = _passwordHashService.GetHash(request.Password),
                IsActive = true
            };

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<UserDto>(user));
        }
    }
}
