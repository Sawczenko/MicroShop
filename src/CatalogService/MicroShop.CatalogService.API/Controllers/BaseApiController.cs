using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public BaseApiController(IMediator mediator)
        {
            Mediator = mediator;
        }

    }
}
