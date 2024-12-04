using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Domain.Repositories;
using FitnessWorkoutTracker.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FitnessWorkoutTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMediator _mediator;

        public AuthController(IConfiguration configuration, IUserRepository userService, IAuthenticationService authenticationService, IMediator mediator)
        {
            _configuration = configuration;
            _userRepository = userService;
            _authenticationService = authenticationService;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel, CancellationToken cancellationToken)
        {
            IActionResult response = NotFound("User not found!");

            var loginResponse = await _authenticationService.LoginAsync(loginModel, cancellationToken);
            return response = Ok(new { token = loginResponse });
        }

        [HttpPost("id")]
        public async Task<IActionResult> LogOut([FromBody] int id, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.LogOutAsync(id, cancellationToken);
            return Ok(result);
        }
    }
}
