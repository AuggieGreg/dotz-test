using Dotz.Fidelidade.Application.Dto;
using Dotz.Fidelidade.Application.Product.Commands.ExchangeProducts;
using Dotz.Fidelidade.Application.Product.Queries.GetAllProductsWithPagination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ProductDto>> Get(GetAllProductsWithPaginationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<ExchangedProductsResponse>> Exchange(ExchangeProductsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
