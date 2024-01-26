using MediatR;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.TodoTasks.Queries
{
    public class GetAllTasksQuery : IRequest<IList<TodoTask>>
    {
    }
}
