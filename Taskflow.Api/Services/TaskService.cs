
using Microsoft.EntityFrameworkCore;
using Taskflow.Api.Data;
using Taskflow.Api.Models;

namespace Taskflow.Api.Services
{
    public class TaskService
    {
        private readonly TaskDbContext _context;

        public TaskService(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            task.Id = 0;
            task.CreatedAt = DateTime.UtcNow;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> UpdateAsync(int id, TaskItem updatedTask)
        {
            var task = await GetByIdAsync(id);

            if (task is null)
            {
                return false;
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.status = updatedTask.status;
            task.DueDate = updatedTask.DueDate;
            task.Priority = updatedTask.Priority;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await GetByIdAsync(id);

            if (task is null)
            {
                return false;
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
