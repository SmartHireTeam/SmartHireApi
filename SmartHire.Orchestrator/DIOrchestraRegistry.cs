using SmartHire.Model;
using Microsoft.Extensions.DependencyInjection;

namespace SmartHire.Orchestrator
{
    public static class DIOrchestraRegistry
    {
        public static void RegisterDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => 
            {
                cfg.RegisterServicesFromAssemblies(typeof(DIRegistry).Assembly, typeof(DIOrchestraRegistry).Assembly);
            });
        }
    }
}
