using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartHire.Model.Request;
using SmartHire.Model.Response;

namespace SmartHire.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobDescriptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobDescriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetJobDescription")]
        public async IAsyncEnumerable<JobDescriptionResponse> GetAppUsers(int? RequisitionId)
        {
            await foreach (var item in _mediator.CreateStream(new GetJobDescriptionRequest(RequisitionId)))
            {
                yield return item;
            }
        }
    }
}
