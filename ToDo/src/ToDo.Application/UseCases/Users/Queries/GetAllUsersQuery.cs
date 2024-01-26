using MediatR;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.Users.Queries
{
    public class GetAllUsersQuery : IRequest<IList<User>>
    {
    }
}
