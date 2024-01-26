using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Abstractions;
using ToDo.Application.UseCases.Users.Commands;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.Users.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IToDoApplicationDbContext _context;

        public DeleteUserHandler(IToDoApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
