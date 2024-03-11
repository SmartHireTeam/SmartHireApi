using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartHire.Model.Request;
using SmartHire.Model.Response;

namespace SmartHire.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AppUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAppUsers")]
        public async IAsyncEnumerable<AppUserDetails> GetAppUsers(int? AppUserId)
        {
            await foreach(var item in _mediator.CreateStream(new GetAppUserRequest(AppUserId))) 
            {
                yield return item;
            }
        }
    }
}
