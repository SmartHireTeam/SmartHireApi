
using Microsoft.EntityFrameworkCore;
using SmartHire.Db.Context;
using SmartHire.Model.Request;
using SmartHire.Model.Response;

namespace SmartHire.Db.QueryRepository
{
    public class AppUserQuery : IQuery<GetAppUserRequest, IAsyncEnumerable<AppUserDetails>>
    {
        private readonly QueryContext _queryContext;

        public AppUserQuery(QueryContext queryContext)
        {
            _queryContext = queryContext;
        }
        public async IAsyncEnumerable<AppUserDetails> ExecuteQuery(GetAppUserRequest request)
        {
            var result = from usr in _queryContext.AppUsers.
                         Where(x => request.AppUserId == null || x.AppUserId == request.AppUserId)
                         join lgn in _queryContext.UserLogins on usr.AppUserId equals lgn.AppUserId
                         select new AppUserDetails
                         {
                             AppUserId = usr.AppUserId,
                             FirstName = usr.FirstName,
                             MiddleName = usr.MiddleName,
                             LastName = usr.LastName,
                             Email = usr.Email,
                             Gender = usr.Gender,
                             PhoneNumber = usr.PhoneNumber,
                             Password = lgn.Password,
                         };
            await foreach (var item in result.AsAsyncEnumerable())
            {
                yield return item;
            }
        }
    }
}
