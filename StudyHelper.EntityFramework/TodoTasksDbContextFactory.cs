using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.EntityFramework
{
    public class TodoTasksDbContextFactory
    {
        private readonly DbContextOptions _options;

        public TodoTasksDbContextFactory(DbContextOptions options) { 
            _options = options;
        }

        public TodoTasksDbContext Create() => new TodoTasksDbContext(_options);
    }
}
