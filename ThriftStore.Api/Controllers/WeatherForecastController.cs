using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThriftStore.Application.User;

namespace ThriftStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {
        private readonly IUserService _userService;

        public WeatherForecastController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Post(UserDto user)
        {
            await _userService.RegisterUser(user);

            return Ok();
        }

        [Authorize]
        [HttpGet("/oi")]
        public async Task<IActionResult> Get()
        {

            return Ok();
        }

        [HttpGet("/login")]
        public async Task<IActionResult> GetAuth(string userEmail, string password)
        {
            var result = await _userService.AuthorizeUser(userEmail, password);
            return Ok(result);
        }
    }
}
