using Microsoft.EntityFrameworkCore;

namespace SmartHire.Db.Context
{
    public class QueryContext: BaseContext
    {
        public QueryContext(DbContextOptions<QueryContext> options) : base(options) { }
    }
}
