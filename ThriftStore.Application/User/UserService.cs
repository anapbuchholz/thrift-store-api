using ThriftStore.Infrastructure.Authentication;

namespace ThriftStore.Application.User
{
    internal sealed class UserService : IUserService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public UserService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task RegisterUser(UserDto user)
        {
            await _authenticationRepository.RegisterUserAsync(user.Email, user.Password);
        }

        public async Task<string> AuthorizeUser(string userEmail, string userPassword)
        {
            return await _authenticationRepository.AuthorizeUser(userEmail, userPassword);
        }
    }
}
