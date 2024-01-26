using MediatR;
using ToDo.Application.ViewModels;

namespace ToDo.Application.UseCases.TodoTasks.Commands
{
    public class CreateTaskCommand : IRequest
    {
        public TaskDTO TaskDto { get; set; }
    }
}
