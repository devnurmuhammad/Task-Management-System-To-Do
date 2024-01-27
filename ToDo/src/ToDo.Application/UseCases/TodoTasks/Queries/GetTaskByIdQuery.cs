using MediatR;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.TodoTasks.Queries
{
    public class GetTaskByIdQuery : IRequest<TodoTask>
    {
        public int Id { get; set; }
    }
}
