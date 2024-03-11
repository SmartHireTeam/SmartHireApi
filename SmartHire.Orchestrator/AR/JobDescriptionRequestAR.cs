using MediatR;
using SmartHire.Db;
using SmartHire.Model.Request;
using SmartHire.Model.Response;

using System.Runtime.CompilerServices;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SmartHire.Orchestrator.AR
{
    public class JobDescriptionRequestAR : IStreamRequestHandler<GetJobDescriptionRequest, JobDescriptionResponse>
    {
        private readonly IQuery<GetJobDescriptionRequest, IAsyncEnumerable<JobDescriptionResponse>> _query;

        public JobDescriptionRequestAR(IQuery<GetJobDescriptionRequest, IAsyncEnumerable<JobDescriptionResponse>> query)
        {
            _query = query;
        }

        public async IAsyncEnumerable<JobDescriptionResponse> Handle(GetJobDescriptionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            await foreach (var item in _query.ExecuteQuery(request))
            {
                yield return item;
            }
        }

    }
    
}
