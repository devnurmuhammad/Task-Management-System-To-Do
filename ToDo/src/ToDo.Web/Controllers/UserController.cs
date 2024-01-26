using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.UseCases.Users.Commands;
using ToDo.Application.UseCases.Users.Queries;
using ToDo.Application.ViewModels;
using ToDo.Domain.Entities;

namespace ToDo.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsers()
        {
            IList<User> users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateUser(UserDTO userDTO)
        {
            var user = new CreateUserCommand()
            {
                UserDto = userDTO,
            };
            await _mediator.Send(user);
            return Ok("Created");
        }

        [HttpPatch]
        public async ValueTask<ActionResult<bool>> UpdateUser(UpdateUserCommand updateUser)
        {
            bool result = await _mediator.Send(updateUser);
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<ActionResult<bool>> DeleteUser(int id)
        {
            bool result = await _mediator.Send(new DeleteUserCommand() { Id = id });
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetUserById(int id)
        {
            User user = await _mediator.Send(new GetUserByIdQuery() { Id = id });
            return Ok(user);
        }
    }
}
