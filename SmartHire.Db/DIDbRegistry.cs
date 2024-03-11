using SmartHire.Db.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SmartHire.Db
{
    public static class DIDbRegistry
    {
        public static void RegisterDependencies(IServiceCollection services) 
        {
            services.AddDbContext<CommandContext>(options => 
            {
                options.UseSqlServer(@"Server=tcp:smarthire-sqlsever.database.windows.net,1433;Initial Catalog=smarthiredb;Persist Security Info=False;User ID=dbadmin;Password=Wells@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            });
            services.AddDbContext<QueryContext>(options =>
            {
                options.UseSqlServer(@"Server=tcp:smarthire-sqlsever.database.windows.net,1433;Initial Catalog=smarthiredb;Persist Security Info=False;User ID=dbadmin;Password=Wells@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            });
            RepositoryInjection(services);
        }

        private static void RepositoryInjection(IServiceCollection serviceCollection)
        {
            var assembly = typeof(ICommand<>).Assembly;

            foreach (var type in assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract))
            {
                ContinueIfRepoClass(type, assembly, serviceCollection);
            }
        }

        public static void ContinueIfRepoClass(Type type, Assembly assembly, IServiceCollection serviceCollection)
        {
            var typeinfo = (TypeInfo)type;
            var implInterfaces = typeinfo.ImplementedInterfaces;
            var repointf = typeinfo.ImplementedInterfaces
                .FirstOrDefault(x => x.FullName != null && (x.FullName.Contains(typeof(ICommand<>).Name) || x.FullName.Contains(typeof(IQuery<,>).Name)));
            if (repointf != null)
            {
                foreach (var intf in implInterfaces)
                {
                    if (intf.FullName != null && intf.FullName.Contains(assembly.GetName().Name ?? string.Empty))
                    {
                        serviceCollection.AddScoped(intf, type);
                    }
                }
            }
        }
    }
}
