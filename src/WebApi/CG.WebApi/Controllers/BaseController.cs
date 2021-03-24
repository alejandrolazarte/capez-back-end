using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CG.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; }

        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
