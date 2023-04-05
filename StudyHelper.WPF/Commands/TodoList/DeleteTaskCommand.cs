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

        public override void Execute(object? parameter)
        {
            _todoTasksStore.Delete(_taskId);
        }
        public override Task ExecuteAsync(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
