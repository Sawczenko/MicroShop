using MicroShop.Core.Abstractions.Controllers.Controllers;
using MicroShop.Core.Interfaces.Containers.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : MicroShopControllerBase
    {
        protected BaseApiController(IControllerContainer controllerContainer)
            : base(controllerContainer) { }
    }
}
