using AutoMapper;
using FitnessWorkoutTracker.Application.UseCases.Users.Commands.CreateUserCommand;
using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutTracker.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([FromBody] UserRegisterModel user)
        {
            if (ModelState.IsValid)
            {
                var mappedUser = _mapper.Map<User>(user.User);
                mappedUser.UserAuthentication = _mapper.Map<UserAuthentication>(user.UserAuthentication);
                var result = await _mediator.Send(new CreateUserCommand(mappedUser));
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
