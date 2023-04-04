using StudyHelper.Domain.Commands;
using StudyHelper.Domain.Models;
using StudyHelper.EntityFramework.DTOs;

namespace StudyHelper.EntityFramework.Commands
{
    public class CreateTodoTaskCommand : ICreateTodoTaskCommand
    {
        private readonly TodoTasksDbContextFactory _dbContextFactory;

        public CreateTodoTaskCommand(TodoTasksDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Exectute(TodoTask task)
        {
            using (TodoTasksDbContext dbContext  = _dbContextFactory.Create())
            {
                TodoTaskDto taskDto = new TodoTaskDto()
                {
                    Id = task.Id,
                    Title = task.Title,
                    Deadline = task.Deadline
                };

                dbContext.TodoTasks.Add(taskDto);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
