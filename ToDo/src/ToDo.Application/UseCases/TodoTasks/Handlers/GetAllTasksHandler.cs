using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Abstractions;
using ToDo.Application.UseCases.TodoTasks.Queries;
using ToDo.Domain.Entities;

namespace ToDo.Application.UseCases.TodoTasks.Handlers
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, IList<TodoTask>>
    {
        private readonly IToDoApplicationDbContext _context;

        public GetAllTasksHandler(IToDoApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<TodoTask>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            IList<TodoTask> tasks = await _context.Tasks.Include(x => x.Users).ToListAsync(cancellationToken);
            return tasks;
        }
    }
}
