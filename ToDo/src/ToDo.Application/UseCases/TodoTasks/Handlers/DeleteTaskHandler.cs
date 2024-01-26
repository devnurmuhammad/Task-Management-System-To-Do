using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Abstractions;
using ToDo.Application.UseCases.TodoTasks.Commands;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.TodoTasks.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly IToDoApplicationDbContext _context;

        public DeleteTaskHandler(IToDoApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            TodoTask? task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (task == null)
            {
                return false;
            }
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);
            
            return true;
        }
    }
}
