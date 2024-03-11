using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHire.Db
{
    public interface ICommand<T>
    {
        void CreateTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        Task<bool> Execute(T request);
    }
}
