using System;
using System.Security.Claims;
using Dotz.Fidelidade.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Dotz.Fidelidade.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = Guid.Empty;
            Guid outId;
            if (Guid.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out outId))
                UserId = outId;

            Role = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
        }

        public Guid UserId { get; }

        public string Role { get; }
    }
}
