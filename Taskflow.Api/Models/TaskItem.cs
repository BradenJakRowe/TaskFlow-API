namespace Taskflow.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public TaskPriority Priority { get; set; }
            = TaskPriority.Medium;
        public TaskStatus status { get; set; }
            = TaskStatus.ToDo;
        public DateTime CreatedAt { get; set; }
            = DateTime.UtcNow;


    }

    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Completed
    }
    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }
}
