using MicroShop.Catalog.Core.Application.Features.Products.Queries.GetProducts;
using MicroShop.Catalog.Core.Application.Models;
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
            var pagination = new Pagination();
            pagination.PageSize = 3;

            return Ok(await Mediator.Send(new GetProductsQuery(pagination), cancellationToken));
        }
    }
}
