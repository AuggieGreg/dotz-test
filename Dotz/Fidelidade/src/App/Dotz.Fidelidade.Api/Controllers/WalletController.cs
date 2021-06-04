using Dotz.Fidelidade.Application.Dto;
using Dotz.Fidelidade.Application.Wallet.Queries.GetUserWallet;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<WalletDto>> Get()
        {
            return Ok(await Mediator.Send(new GetUserWalletQuery()));
        }
    }
}
