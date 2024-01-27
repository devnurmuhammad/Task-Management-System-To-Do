using ToDo.Domain.Enums;

namespace ToDo.Application.ViewModels
{
    public class TaskDTO
    {
        public string TaskName { get; set; } = default!;
        public string? Definition { get; set; }
        public DateTime Deadline { get; set; }
        public IsProgress? Progress { get; set; } = IsProgress.ToDo;
    }
}
