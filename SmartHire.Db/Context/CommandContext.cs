using Microsoft.EntityFrameworkCore;

namespace SmartHire.Db.Context
{
    public class CommandContext: BaseContext
    {
        public CommandContext(DbContextOptions<CommandContext> options) : base(options) { }
    }
}
