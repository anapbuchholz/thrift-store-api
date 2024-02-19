using Microsoft.Extensions.DependencyInjection;
using ThriftStore.Infrastructure;

namespace ThriftStore.IoC
{
    public static class InfrastructureDependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDependencies();
        }
    }
}
