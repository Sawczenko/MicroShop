using MicroShop.CatalogService.Application.Features.Products.Requests.Managers.GetProducts;
using MicroShop.Core.Interfaces.Containers.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Catalog.API.Controllers
{
    public class ProductsController : BaseApiController
    {
        public ProductsController(IControllerContainer controllerContainer) 
            : base(controllerContainer) { }

        [HttpGet("")]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            return await ExecuteManager(new GetProductsManager(), cancellationToken);
        }
    }
}
