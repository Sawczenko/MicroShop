using MicroShop.CatalogService.Application.Features.ProductTypes.Requests.Managers.GetProductTypes;
using MicroShop.Core.Interfaces.Containers.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Catalog.API.Controllers
{
    public class ProductTypesController : BaseApiController
    {
        public ProductTypesController(IControllerContainer controllerContainer) 
            : base(controllerContainer) { }

        [HttpGet("")]
        public async Task<IActionResult> GetProductTypes(CancellationToken cancellationToken)
        {
            return await ExecuteManager(new GetProductTypesManager(), cancellationToken);
        }
    }
}
