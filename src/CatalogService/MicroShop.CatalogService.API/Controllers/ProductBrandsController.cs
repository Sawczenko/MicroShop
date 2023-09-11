using MicroShop.CatalogService.Application.Features.ProductBrands.Requests.Managers.GetProductBrands;
using MicroShop.Core.Interfaces.Containers.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Catalog.API.Controllers
{
    public class ProductBrandsController : BaseApiController
    {
        public ProductBrandsController(IControllerContainer controllerContainer) 
            : base(controllerContainer) { }

        [HttpGet("")]
        public async Task<IActionResult> GetProductBrands(CancellationToken cancellationToken)
        {
            return await ExecuteManager(new GetProductBrandsManager(), cancellationToken);
        }
    }
}
