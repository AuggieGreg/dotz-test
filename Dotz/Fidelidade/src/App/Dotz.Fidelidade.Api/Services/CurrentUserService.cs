using System.Security.Claims;
using Dotz.Fidelidade.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Dotz.Fidelidade.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            Role = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
        }

        public string UserId { get; }

        public string Role { get; }
    }
}
