using StudyHelper.Domain.Commands;
using StudyHelper.EntityFramework.DTOs;

namespace StudyHelper.EntityFramework.Commands
{
    public class DeleteTodoTaskCommand : IDeleteTodoTaskCommand
    {
        public readonly TodoTasksDbContextFactory _dbContextFactory;
        public DeleteTodoTaskCommand(TodoTasksDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task Exectute(Guid id)
        {
            using (TodoTasksDbContext dbContext = _dbContextFactory.Create())
            {
                TodoTaskDto taskDto = new TodoTaskDto()
                {
                    Id = id
                };

                dbContext.TodoTasks.Remove(taskDto);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
