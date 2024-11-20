using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Application.UseCases.UserAuthentication.VerifyLoginAndPasswordQuery;
using FitnessWorkoutTracker.Domain.Repositories;
using FitnessWorkoutTracker.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FitnessWorkoutTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMediator _mediator;

        public LoginController(IConfiguration configuration, IUserRepository userService, IAuthenticationService authenticationService, IMediator mediator)
        {
            _configuration = configuration;
            _userRepository = userService;
            _authenticationService = authenticationService;
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel, CancellationToken cancellationToken)
        {
            IActionResult response = Unauthorized();
            var verified = await _mediator.Send(new VerifyLoginAndPasswordQuery(loginModel), cancellationToken);

            if (verified)
            {
                var tokenString = _authenticationService.GenerateJsonWebToken(cancellationToken);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
    }
}
