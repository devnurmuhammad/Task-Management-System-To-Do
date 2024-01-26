using MediatR;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.Users.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
