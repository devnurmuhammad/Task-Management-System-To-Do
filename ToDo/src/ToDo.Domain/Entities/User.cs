namespace ToDo.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public ICollection<TodoTask>? Tasks { get; set; }
    }
}
