using System.ComponentModel.DataAnnotations.Schema;
using static ToDo.Domain.Enums.ProgressEnum;

namespace ToDo.Domain.Entities
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = default!;
        public string? Definition { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; } = false;
        public IsProgress Progress { get; set; } = IsProgress.ToDo;
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? Users { get; set; }
    }
}