using AutoFixture;
using NSubstitute;
using ThriftStore.Application.User;
using ThriftStore.Infrastructure.Authentication;

namespace ThriftStore.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly Fixture _fixture;

        public UserServiceTest()
        {
            _authenticationRepository = Substitute.For<IAuthenticationRepository>();
            _userService = new UserService(_authenticationRepository);
            _fixture = new Fixture();
        }

        [TestMethod]
        public async Task RegisterUser_WhenUserAccessFirstTime_ShouldReturnPasswordAndEmail()
        {
            var userDto = _fixture.Create<UserDto>();
            var userEmail = userDto.Email = "person@email.com";
            var userPassword = userDto.Password = "password";

            await _userService.RegisterUser(userDto);

            await _authenticationRepository.Received(1).RegisterUserAsync(userEmail, userPassword);
        }
    }
}