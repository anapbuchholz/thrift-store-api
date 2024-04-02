using Firebase.Auth;
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

            var userRecord = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);

            return userRecord.Uid;
        }

        public async Task<string> AuthorizeUser(string userEmail, string userPassword)
        {

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCZqYUkA54PvuVY0wiYdd43OOUGAQUhdIA"));
            var result = await authProvider.SignInWithEmailAndPasswordAsync(userEmail, userPassword);

            return result.FirebaseToken;
        }
    }
}
