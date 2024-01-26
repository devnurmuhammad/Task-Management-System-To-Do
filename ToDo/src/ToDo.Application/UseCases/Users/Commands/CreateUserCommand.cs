using MediatR;
using ToDo.Application.ViewModels;

namespace ToDo.Application.UseCases.Users.Commands
{
    public class CreateUserCommand : IRequest
    {
        public UserDTO UserDto { get; set; }
    }
}
