namespace Demo.Todo.Domain
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public DateTime DueDate { get; set; }
        public TodoStatus Status { get; set; }
    }
}
