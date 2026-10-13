using Taskflow.Api.Models;

namespace Taskflow.Api.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public List<TaskItem> GetAll()
        {
            return _tasks;
        }

        public TaskItem? GetById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public TaskItem Create(TaskItem task)
        {
            task.Id = _nextId++;
            task.CreatedAt = DateTime.UtcNow;
            _tasks.Add(task);

            return task;
        }

        public bool Update(int id, TaskItem updatedTask)
        {

            var task = GetById(id);
            if (task is null)
            {
                return false;
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.status = updatedTask.status;
            task.DueDate = updatedTask.DueDate;
            task.Priority = updatedTask.Priority;

            return true;
        }



    }
}
