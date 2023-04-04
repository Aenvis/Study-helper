using Microsoft.EntityFrameworkCore;
using StudyHelper.Domain.Models;
using StudyHelper.Domain.Queries;
using StudyHelper.EntityFramework.DTOs;

namespace StudyHelper.EntityFramework.Queries
{
    public class GetTodoTasksQuery : IGetTodoTasksQuery
    {
        private readonly TodoTasksDbContextFactory _dbContextFactory;
        public GetTodoTasksQuery(TodoTasksDbContextFactory dbContextFactory) 
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<IEnumerable<TodoTask>> Execute()
        {
            using (TodoTasksDbContext dbContext = _dbContextFactory.Create())
            {
                IEnumerable<TodoTaskDto> todoTaskDtos = await dbContext.TodoTasks.ToListAsync();

                return todoTaskDtos.Select(x => new TodoTask(x.Id, x.Title, x.Deadline));
            }
        }
    }
}
