using MediatR;

namespace MicroShop.Catalog.API.Controllers
{
    public class ProductTypesController : BaseApiController
    {
        public ProductTypesController(IMediator mediator)
            : base(mediator) { }
    }
}
