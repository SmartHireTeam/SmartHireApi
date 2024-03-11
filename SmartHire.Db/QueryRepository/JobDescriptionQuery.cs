using Microsoft.EntityFrameworkCore;
using SmartHire.Db.Context;
using SmartHire.Model.Request;
using SmartHire.Model.Response;

namespace SmartHire.Db.QueryRepository
{
    public class JobDescriptionQuery : IQuery<GetJobDescriptionRequest, IAsyncEnumerable<JobDescriptionResponse>>
    {
        private readonly QueryContext _queryContext;

        public JobDescriptionQuery(QueryContext queryContext)
        {
            _queryContext = queryContext;
        }
        public async IAsyncEnumerable<JobDescriptionResponse> ExecuteQuery(GetJobDescriptionRequest request)
        {
            var result = from jdr in _queryContext.JobDescriptions.
                        Where(x => request.RequisitionId == null || x.RequisitionId == request.RequisitionId)
                         select new JobDescriptionResponse
                         {
                             RequisitionId=jdr.RequisitionId,
                             JobCode=jdr.JobCode,
                             DomainName=jdr.DomainName,
                             FileName=jdr.FileName,
                             FilePath=jdr.FilePath,
                             FileFormat=jdr.FileFormat,
                             UploadedBy=jdr.UploadedBy,
                             UploadedAt=jdr.UploadedAt,
                         };
            await foreach (var item in result.AsAsyncEnumerable())
            {
                yield return item;
            }

        }

    }
}
