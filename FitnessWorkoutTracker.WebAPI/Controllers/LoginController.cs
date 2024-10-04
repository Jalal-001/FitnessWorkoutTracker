using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Application.Interfaces.Authentication;
using FitnessWorkoutTracker.Application.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FitnessWorkoutTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        public LoginController(IConfiguration configuration, IUserService userService, IAuthenticationService authenticationService)
        {
            _configuration = configuration;
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginModel, CancellationToken cancellationToken)
        {
            IActionResult response = Unauthorized();

            var verified = await _userService.VerifyLoginAndPassword(loginModel, cancellationToken);

            if (verified)
            {
                var tokenString = await _authenticationService.GenerateJsonWebToken(cancellationToken);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
    }
}
