using StudyHelper.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands.TodoList
{
    public class DeleteTaskCommand : AsyncCommandBase
    {
        private Guid _taskId;
        private TodoTasksStore _todoTasksStore;

        public DeleteTaskCommand(Guid id, TodoTasksStore todoTasksStore)
        {
            this._taskId = id;
            this._todoTasksStore = todoTasksStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _todoTasksStore.Delete(_taskId);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
