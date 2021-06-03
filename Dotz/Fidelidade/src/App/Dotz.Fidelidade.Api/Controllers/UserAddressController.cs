using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Dto;
using Dotz.Fidelidade.Application.UserAddress.Commands.Create;
using Dotz.Fidelidade.Application.UserAddress.Commands.Delete;
using Dotz.Fidelidade.Application.UserAddress.Commands.Update;
using Dotz.Fidelidade.Application.UserAddress.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResult<UserAddressDto>>> Create(CreateUserAddressCommand createUserAddressCommand)
        {
            return Ok(await Mediator.Send(createUserAddressCommand));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResult<UserAddressDto>>> Update(UpdateUserAddressCommand updateUserAddressCommand)
        {
            return Ok(await Mediator.Send(updateUserAddressCommand));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<UserAddressDto>>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetUserAddressQuery() { UserAddressId = id }));
        }

        [HttpGet()]
        public async Task<ActionResult<ServiceResult<UserAddressDto>>> Get()
        {
            return Ok(await Mediator.Send(new GetAllUserAddressQuery()));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<UserAddressDto>>> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteUserAddressCommand() { Id = id }));
        }
    }
}
