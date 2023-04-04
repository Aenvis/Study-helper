using Microsoft.EntityFrameworkCore;
using StudyHelper.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.EntityFramework
{
    public class TodoTasksDbContext : DbContext
    {
        public DbSet<TodoTaskDto> TodoTasks { get; set; }

        public TodoTasksDbContext(DbContextOptions options) : base(options) { }
    }
}
