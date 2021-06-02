using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Dto;
using Dotz.Fidelidade.Application.User.Commands.Activate;
using Dotz.Fidelidade.Application.User.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dotz.Fidelidade.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] CreateUserCommand user)
        {
            return Ok(await Mediator.Send(user));
        }

        [HttpPost]
        [Route("Activate")]
        public async Task<ActionResult<ServiceResult<ActivateUserResponse>>> Activate([FromBody] ActivateUserCommand activateUserCommand)
        {
            return Ok(await Mediator.Send(activateUserCommand));
        }
    }
}
