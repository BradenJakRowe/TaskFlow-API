using Microsoft.EntityFrameworkCore;
using Taskflow.Api.Models;

namespace Taskflow.Api.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) 
            : base(options) 
        {
        }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();
    }
}
