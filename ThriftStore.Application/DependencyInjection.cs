using Microsoft.Extensions.DependencyInjection;
using ThriftStore.Application.User;

namespace ThriftStore.Application
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
