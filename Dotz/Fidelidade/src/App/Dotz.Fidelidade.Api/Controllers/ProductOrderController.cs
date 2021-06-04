using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Dto;
using Dotz.Fidelidade.Application.ProductOrder.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrderController : BaseApiController
    {
        [HttpGet()]
        public async Task<ActionResult<PaginatedList<ProductOrderDto>>> Get(GetProductOrderWithPaginationByStatus query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
