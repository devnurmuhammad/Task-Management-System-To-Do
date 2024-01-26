using MediatR;
using ToDo.Application.Abstractions;
using ToDo.Application.UseCases.Users.Commands;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.Users.Handlers
{
    public class CreateUserHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IToDoApplicationDbContext _context;

        public CreateUserHandler(IToDoApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User()
            {
                UserName = request.UserDto.UserName,
                Password = request.UserDto.Password
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
