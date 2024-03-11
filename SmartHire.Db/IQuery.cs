using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHire.Db
{
    public interface IQuery<T, U>
    {
        U ExecuteQuery(T request);
    }
}
