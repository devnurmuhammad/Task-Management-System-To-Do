using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Abstractions;
using ToDo.Application.UseCases.Users.Queries;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.Users.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IList<User>>
    {
        private readonly IToDoApplicationDbContext _context;

        public GetAllUsersHandler(IToDoApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            IList<User> users = await _context.Users.Include(x => x.Tasks).ToListAsync(cancellationToken);
            return users;
        }
    }
}
