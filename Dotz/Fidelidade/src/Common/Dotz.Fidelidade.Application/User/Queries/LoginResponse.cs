using Dotz.Fidelidade.Application.Dto;

namespace Dotz.Fidelidade.Application.ApplicationUser.Queries.GetToken
{
    public class LoginResponse
    {
        public UserDto User { get; set; }

        public string Token { get; set; }
    }
}
