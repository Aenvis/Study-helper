using StudyHelper.Domain.Commands;
using StudyHelper.Domain.Models;
using StudyHelper.EntityFramework.DTOs;

namespace StudyHelper.EntityFramework.Commands
{
    public class UpdateTodoTaskCommand : IUpdateTodoTaskCommand
    {
        private readonly TodoTasksDbContextFactory _dbContextFactory;
        
        public UpdateTodoTaskCommand(TodoTasksDbContextFactory contextFactory)
        {

            _dbContextFactory = contextFactory;   

        }

        public async Task Exectute(TodoTask task)
        {
            using (TodoTasksDbContext dbContext = _dbContextFactory.Create())
            {
                TodoTaskDto taskDto = new TodoTaskDto()
                {
                    Id = task.Id,
                    Title = task.Title,
                    Deadline = task.Deadline
                };

                dbContext.TodoTasks.Update(taskDto);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
