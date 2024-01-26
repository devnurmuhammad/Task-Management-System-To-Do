using MediatR;

namespace ToDo.Application.UseCases.Users.Commands
{
    public class CreateUserCommand : IRequest
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
