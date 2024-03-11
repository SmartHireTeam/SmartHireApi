using MediatR;
using SmartHire.Db;
using SmartHire.Model.Request;
using SmartHire.Model.Response;
using System.Runtime.CompilerServices;


namespace SmartHire.Orchestrator.AR
{
    public class GetAppUserRequestAR : IStreamRequestHandler<GetAppUserRequest, AppUserDetails>
    {
        private readonly IQuery<GetAppUserRequest, IAsyncEnumerable<AppUserDetails>> _query;
        public GetAppUserRequestAR(IQuery<GetAppUserRequest, IAsyncEnumerable<AppUserDetails>> query)
        {
            _query = query;
        }

        public async IAsyncEnumerable<AppUserDetails> Handle(GetAppUserRequest request, [EnumeratorCancellation]  CancellationToken cancellationToken)
        {
            await foreach (var item in _query.ExecuteQuery(request))
            {
                yield return item;
            }
        }
    }
}
