namespace Dotz.Fidelidade.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        string Role { get; }
    }
}
