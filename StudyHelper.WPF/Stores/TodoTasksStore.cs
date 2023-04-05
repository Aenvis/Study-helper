using StudyHelper.Domain.Commands;
using StudyHelper.Domain.Models;
using StudyHelper.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Stores
{
    public class TodoTasksStore
    {
        private readonly List<TodoTask> _todoTasks;
        public IEnumerable<TodoTask> TodoTasks => _todoTasks;

        private readonly IGetTodoTasksQuery _getTodoTasksQuery;
        private readonly ICreateTodoTaskCommand _createTodoTaskCommand;
        private readonly IUpdateTodoTaskCommand _updateTodoTaskCommand;
        private readonly IDeleteTodoTaskCommand _deleteTodoTaskCommand;

        public Action? TodoTasksLoaded;
        public Action<TodoTask>? TodoTaskCreated;
        public Action<TodoTask>? TodoTaskUpdated;
        public Action<Guid>? TodoTaskDeleted;


        public TodoTasksStore(IGetTodoTasksQuery     getTodoTasksQuery,
                              ICreateTodoTaskCommand createTodoTaskCommand,
                              IUpdateTodoTaskCommand updateTodoTaskCommand,
                              IDeleteTodoTaskCommand deleteTodoTaskCommand)
        {
            _getTodoTasksQuery = getTodoTasksQuery;
            _createTodoTaskCommand = createTodoTaskCommand;
            _updateTodoTaskCommand = updateTodoTaskCommand;
            _deleteTodoTaskCommand = deleteTodoTaskCommand;
            _todoTasks = new List<TodoTask>();
        }

        public async Task Load()
        {
            var todoTasks = await _getTodoTasksQuery.Execute();
            _todoTasks.Clear();
            _todoTasks.AddRange(todoTasks);

            TodoTasksLoaded?.Invoke();
        }

        public async Task Create(TodoTask task)
        {
            await _createTodoTaskCommand.Exectute(task);

            _todoTasks.Add(task);

            TodoTaskCreated?.Invoke(task);
        }

        public async Task Update(TodoTask task)
        {
            await _updateTodoTaskCommand.Exectute(task);

            var taskId = _todoTasks.FindIndex(x => x.Id == task.Id);

            if (taskId != -1)
            {
                _todoTasks[taskId] = task;
            }
            else _todoTasks.Add(task);

            TodoTaskUpdated?.Invoke(task);
        }

        public async Task Delete(Guid id)
        {
            await _deleteTodoTaskCommand.Exectute(id);

            _todoTasks.RemoveAll(x => x.Id == id);

            TodoTaskDeleted?.Invoke(id);
        }
    }
}
