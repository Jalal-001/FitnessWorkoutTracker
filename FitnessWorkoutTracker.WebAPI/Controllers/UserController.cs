using FitnessWorkoutTracker.Application.UseCases.Users.Commands.CreateUserCommand;
using FitnessWorkoutTracker.Shared.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([FromBody] UserDto user)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateUserCommand(user));
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
