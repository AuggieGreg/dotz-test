using System;

namespace Dotz.Fidelidade.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }

        string Role { get; }
    }
}
