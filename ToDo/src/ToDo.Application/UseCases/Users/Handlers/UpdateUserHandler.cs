using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Abstractions;
using ToDo.Application.UseCases.Users.Commands;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.Users.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IToDoApplicationDbContext _context;

        public UpdateUserHandler(IToDoApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
            {
                return false;
            }
            user.Password = request.Password;
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}