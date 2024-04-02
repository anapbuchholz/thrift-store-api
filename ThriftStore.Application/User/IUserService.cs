namespace ThriftStore.Application.User
{
    public interface IUserService
    {
        Task RegisterUser(UserDto user);
        Task<string> AuthorizeUser(string userEmail, string userPassword);
    }
}
