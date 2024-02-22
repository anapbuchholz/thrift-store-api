using Microsoft.Extensions.DependencyInjection;
using ThriftStore.Application;

namespace ThriftStore.IoC
{
    public static class ApplicationDependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddDependencies();
        }
    }
}
