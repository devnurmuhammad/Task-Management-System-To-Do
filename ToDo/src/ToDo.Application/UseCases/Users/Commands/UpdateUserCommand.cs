using MediatR;

namespace ToDo.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
