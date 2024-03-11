using MediatR;
using SmartHire.Model.Response;

namespace SmartHire.Model.Request
{
    public class GetJobDescriptionRequest(int? RequisitionId) : IStreamRequest<JobDescriptionResponse>
    {
        public int? RequisitionId { get; init; } = RequisitionId;
    }
}
