using BlazorToDo.Enums;

namespace BlazorToDo.Entities
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = default!;
        public string? Definition { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime Deadline { get; set; }
        private IsProgress progress { get; set; }
        public int Progress
        {
            get
            {
                return (int)progress;
            }
            set
            {
                progress = (IsProgress)value;

            }
        }
    }
}