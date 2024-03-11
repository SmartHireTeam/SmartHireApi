using SmartHire.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace SmartHire.Db.Context
{
    public class BaseContext: DbContext 
    {
        public BaseContext(DbContextOptions options): base(options) { }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<JobDescription> JobDescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseContext).Assembly);
        }
    }
}
