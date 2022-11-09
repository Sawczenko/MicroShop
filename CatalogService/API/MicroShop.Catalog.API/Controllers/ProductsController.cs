using MicroShop.Catalog.Core.Application.Features.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;
using Mediator;

namespace MicroShop.Catalog.API.Controllers
{
    public class ProductsController : BaseApiController
    {
        public ProductsController(IMediator mediator) 
            : base(mediator) { }

        [HttpGet("elo")]
        public async Task GetProducts(CancellationToken cancellationToken)
        {
           await Mediator.Send(new GetProductsQuery(), cancellationToken);
        }
    }
}
