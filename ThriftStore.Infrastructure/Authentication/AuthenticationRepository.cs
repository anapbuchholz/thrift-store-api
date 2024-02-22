using FirebaseAdmin.Auth;

namespace ThriftStore.Infrastructure.Authentication
{
    internal sealed class AuthenticationRepository : IAuthenticationRepository
    {
        public async Task<string> RegisterUserAsync(string email, string password)
        {
            var userArgs = new UserRecordArgs
            { 
                Email = email, 
                Password = password 
            };

            var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);

            return userRecord.Uid;
        }
    }
}
