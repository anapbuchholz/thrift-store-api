namespace ThriftStore.Infrastructure.Authentication
{
    internal interface IAuthenticationService
    {
        Task<string> RegisterUserAsync(string email, string password);
    }
}
