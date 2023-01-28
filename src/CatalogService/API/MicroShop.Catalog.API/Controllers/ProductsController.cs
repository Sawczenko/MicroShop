using MicroShop.Catalog.Application.Features.Products.Managers.GetProducts;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace MicroShop.Catalog.API.Controllers
{
    public class ProductsController : BaseApiController
    {
        public ProductsController(IMediator mediator)
            : base(mediator) { }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetProductsManager(), cancellationToken));
        }
    }
}
