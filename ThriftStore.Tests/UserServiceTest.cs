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
        private readonly UserDto userDto;
        private readonly string userEmail;
        private readonly string userPassword;

        public UserServiceTest()
        {
            _authenticationRepository = Substitute.For<IAuthenticationRepository>();
            _userService = new UserService(_authenticationRepository);
            _fixture = new Fixture();
            userDto = _fixture.Create<UserDto>();
            userEmail = userDto.Email = "person@email.com";
            userPassword = userDto.Password = "password";
        }

        [TestMethod]
        public async Task RegisterUser_WhenUserAccessFirstTime_ShouldReturnPasswordAndEmail()
        {
            await _userService.RegisterUser(userDto);

            await _authenticationRepository.Received(1).RegisterUserAsync(userEmail, userPassword);
        }

        [TestMethod]
        public async Task AuthorizeUser_WhenAccessing_Should()
        {
            await _userService.AuthorizeUser(userEmail, userPassword);

            await _authenticationRepository.Received(1).AuthorizeUser(userEmail, userPassword);
        }
    }
}