using MediatR;

namespace MicroShop.Catalog.API.Controllers
{
    public class ProductBrandsController : BaseApiController
    {
        public ProductBrandsController(IMediator mediator)
            : base(mediator) { }
    }
}
