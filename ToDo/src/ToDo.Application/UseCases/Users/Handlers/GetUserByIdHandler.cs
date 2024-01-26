using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Abstractions;
using ToDo.Application.UseCases.Users.Queries;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.Users.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IToDoApplicationDbContext _context;

        public GetUserByIdHandler(IToDoApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
            {
                return new User();
            }
            return user;
        }
    }
}
