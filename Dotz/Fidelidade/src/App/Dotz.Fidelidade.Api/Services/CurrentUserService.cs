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
        }

        public string UserId { get; }
    }
}
