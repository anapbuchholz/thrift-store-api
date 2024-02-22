namespace ThriftStore.Application.User
{
    public interface IUserService
    {
        Task RegisterUser(UserDto user);
    }
}
