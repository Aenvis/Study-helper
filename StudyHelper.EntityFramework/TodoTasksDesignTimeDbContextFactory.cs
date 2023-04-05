using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.EntityFramework
{
    public class TodoTasksDesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodoTasksDbContext>
    {
        public TodoTasksDbContext CreateDbContext(string[] args)
        {
            return new TodoTasksDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=todoTasks.db").Options);
        }
    }
}
