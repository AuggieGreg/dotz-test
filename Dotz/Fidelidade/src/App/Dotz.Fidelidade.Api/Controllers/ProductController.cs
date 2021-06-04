using Dotz.Fidelidade.Application.Dto;
using Dotz.Fidelidade.Application.Product.Queries.GetAllProductsWithPagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
