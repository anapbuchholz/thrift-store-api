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
    }
}
