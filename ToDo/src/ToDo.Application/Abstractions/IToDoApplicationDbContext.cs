using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.Application.Abstractions
{
    public interface IToDoApplicationDbContext
    {
        public DbSet<TodoTask> Tasks { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
