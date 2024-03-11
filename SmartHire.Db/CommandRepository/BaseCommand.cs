using SmartHire.Db.Context;
using SmartHire.Db.Entities;

namespace SmartHire.Db.CommandRepository
{
    public abstract class BaseCommand : ICommand<AppUser>
    {
        private readonly CommandContext _commandContext;

        protected CommandContext CommandContext { get { return _commandContext; } }

        protected BaseCommand(CommandContext commandContext)
        {
            _commandContext = commandContext;
        }

        public async Task CommitTransaction()
        {
            await _commandContext.Database.CommitTransactionAsync();
        }

        public void CreateTransaction()
        {
            _commandContext.Database.BeginTransaction();
        }

        public async Task<bool> Execute(AppUser request)
        {

            try
            {
                var result = false;
                CreateTransaction();
                result = await ExecuteNonQuery(request);
                await CommitTransaction();
                return result;
            }
            catch
            {
                await RollbackTransaction();
                throw;
            }
        }

        public async Task RollbackTransaction()
        {
            await _commandContext.Database.RollbackTransactionAsync();
        }

        public abstract Task<bool> ExecuteNonQuery(AppUser request);
    }
}
