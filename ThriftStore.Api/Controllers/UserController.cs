using Microsoft.AspNetCore.Mvc;
using ThriftStore.Application.User;

namespace ThriftStore.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost()]
        [Route("/user")]
        public async Task<IActionResult> Post(UserDto user)
        {
            await _userService.RegisterUser(user);

            return Ok();
        }

        [HttpGet]
        [Route("/user/auth-token")]
        public async Task<IActionResult> GetAuth(string userEmail, string password)
        {
            var result = await _userService.AuthorizeUser(userEmail, password);
            return Ok(result);
        }
    }
}
