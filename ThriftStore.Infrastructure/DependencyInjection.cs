using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.DependencyInjection;
using ThriftStore.Infrastructure.Authentication;

namespace ThriftStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("firebase.json")
            });
        }
    }
}
