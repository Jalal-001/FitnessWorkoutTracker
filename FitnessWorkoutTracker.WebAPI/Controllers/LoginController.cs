using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Domain.Repositories;
using FitnessWorkoutTracker.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FitnessWorkoutTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userService;
        private readonly IAuthenticationService _authenticationService;
        public LoginController(IConfiguration configuration, IUserRepository userService, IAuthenticationService authenticationService)
        {
            _configuration = configuration;
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginModel, CancellationToken cancellationToken)
        {
            //IActionResult response = Unauthorized();

            //var verified = await _authenticationService.CheckUserExistAsync(UserDto, cancellationToken);

            //if (verified)
            //{
            //    var tokenString = await _authenticationService.GenerateJsonWebToken(cancellationToken);
            //    response = Ok(new { token = tokenString });
            //}
            //return response;
            return Ok(loginModel);
        }
    }
}
