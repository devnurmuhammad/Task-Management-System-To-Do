using MediatR;

namespace ToDo.Application.UseCases.TodoTasks.Commands
{
    public class DeleteTaskCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
