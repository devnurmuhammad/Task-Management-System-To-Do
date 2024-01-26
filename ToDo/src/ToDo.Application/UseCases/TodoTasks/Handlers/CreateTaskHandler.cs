using MediatR;
using ToDo.Application.Abstractions;
using ToDo.Application.UseCases.TodoTasks.Commands;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.TodoTasks.Handlers
{
    public class CreateTaskHandler : AsyncRequestHandler<CreateTaskCommand>
    {
        private readonly IToDoApplicationDbContext _context;

        public CreateTaskHandler(IToDoApplicationDbContext context)
        {
            _context = context;
        }
        protected override async Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            TodoTask task = new TodoTask()
            {
               TaskName = request.TaskDto.TaskName,
               Definition = request.TaskDto.Definition,
               Deadline = request.TaskDto.Deadline,
               UserId = request.TaskDto.UserId,
            };
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
