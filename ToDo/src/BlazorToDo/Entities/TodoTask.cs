using BlazorToDo.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorToDo.Entities
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = default!;
        public string? Definition { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime Deadline { get; set; }
        public IsProgress Progress { get; set; } = IsProgress.ToDo;
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? Users { get; set; }
    }
}