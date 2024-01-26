using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Abstractions;
using ToDo.Application.UseCases.TodoTasks.Commands;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.TodoTasks.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly IToDoApplicationDbContext _context;

        public UpdateTaskHandler(IToDoApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            TodoTask? task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (task == null)
            {
                return false;
            }
            task.TaskName = request.TaskName;
            task.Definition = request.Definition;
            task.Deadline = request.Deadline;
            task.Progress = request.Progress;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
