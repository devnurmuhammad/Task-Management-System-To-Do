using ToDo.Domain.Enums;

namespace ToDo.Domain.Entities
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = default!;
        public string? Definition { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime Deadline { get; set; }
        public IsProgress Progress { get; set; } = IsProgress.ToDo;

    }
}