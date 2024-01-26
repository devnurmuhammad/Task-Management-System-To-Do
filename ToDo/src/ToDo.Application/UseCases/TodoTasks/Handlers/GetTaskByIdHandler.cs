using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Abstractions;
using ToDo.Application.UseCases.TodoTasks.Queries;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.TodoTasks.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TodoTask>
    {
        private readonly IToDoApplicationDbContext _context;

        public GetTaskByIdHandler(IToDoApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TodoTask> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            TodoTask? task = await _context.Tasks.Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == request.Id);
            if (task == null)
            {
                return new TodoTask();
            }
            return task;
        }
    }
}
