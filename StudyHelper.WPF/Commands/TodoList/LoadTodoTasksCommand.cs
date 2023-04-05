using StudyHelper.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands
{
    public class LoadTodoTasksCommand : AsyncCommandBase
    {
        private readonly TodoTasksStore _todoTasksStore;
        public LoadTodoTasksCommand(TodoTasksStore todoTasksStore)
        {
            _todoTasksStore = todoTasksStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _todoTasksStore.Load();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
