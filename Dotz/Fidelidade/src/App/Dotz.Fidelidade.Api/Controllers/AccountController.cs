using Microsoft.AspNetCore.Mvc;
using Dotz.Fidelidade.Application.ApplicationUser.Queries.GetToken;
using System.Threading.Tasks;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.User.Commands.Activate;

namespace Dotz.Fidelidade.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseApiController
    {
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Login(GetTokenQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}