using MicroShop.Catalog.Core.Application.Features.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;
using Mediator;

namespace MicroShop.Catalog.API.Controllers
{
    public class ProductsController : BaseApiController
    {
        public ProductsController(IMediator mediator) 
            : base(mediator) { }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductsQuery(), cancellationToken));
        }
    }
}
