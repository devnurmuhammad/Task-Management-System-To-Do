using MediatR;
using ToDo.Domain.Enums;

namespace ToDo.Application.UseCases.TodoTasks.Commands
{
    public class UpdateTaskCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = default!;
        public string? Definition { get; set; }
        public DateTime Deadline { get; set; }
        public IsProgress Progress { get; set; } = IsProgress.ToDo;
    }
}
