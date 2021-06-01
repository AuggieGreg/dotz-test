using System;
using System.Collections.Generic;
using System.Linq;
using Dotz.Fidelidade.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.ApplicationUser.Queries.GetToken;
using System.Threading.Tasks;
using Dotz.Fidelidade.Application.Common.Models;

namespace Dotz.Fidelidade.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : BaseApiController
    {
        readonly ITokenService _tokenService;
        public AccountController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Create(GetTokenQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}