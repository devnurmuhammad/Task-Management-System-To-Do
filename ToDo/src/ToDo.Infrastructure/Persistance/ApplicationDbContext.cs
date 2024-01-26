using Microsoft.EntityFrameworkCore;
using ToDo.Application.Abstractions;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IToDoApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<TodoTask> Tasks { get; set; }
    }
}
