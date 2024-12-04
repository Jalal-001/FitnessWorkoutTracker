using AutoMapper;
using FitnessWorkoutTracker.Application.UseCases.Users.Commands.CreateUserCommand;
using FitnessWorkoutTracker.Application.UseCases.Users.Commands.UpdateUserCommand;
using FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetAllUserQuery;
using FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetUserByIdQuery;
using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Shared.DTOs.User;
using FitnessWorkoutTracker.Shared.Models;
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
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _mediator.Send(new GetAllUserQuery());
            return Json(_mapper.Map<ICollection<UserDto>>(users));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Json(_mapper.Map<UserDto>(user));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserDto user)
        {
            var mappedUser = _mapper.Map<User>(user);
            await _mediator.Send(new UpdateUserCommand(mappedUser));
            return Ok();
        }

        [Authorize]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody] UserRegisterModel user)
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
