namespace ThriftStore.Infrastructure.Authentication
{
    public interface IAuthenticationRepository
    {
        Task<string> RegisterUserAsync(string email, string password);
        Task<string> AuthorizeUser(string userEmail, string userPassword);
    }
}
