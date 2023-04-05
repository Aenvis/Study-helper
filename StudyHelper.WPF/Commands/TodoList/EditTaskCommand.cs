using StudyHelper.Domain.Models;
using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands
{
    public class EditTaskCommand : AsyncCommandBase
    {
        private readonly EditTaskViewModel _editTaskViewModel;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly TodoTasksStore _todoTasksStore;

        public EditTaskCommand(EditTaskViewModel editTaskViewModel, ModalNavigationStore modalNavigationStore, TodoTasksStore todoTasksStore)
        {
            _editTaskViewModel = editTaskViewModel;
            _modalNavigationStore = modalNavigationStore;
            _todoTasksStore = todoTasksStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            var formViewModel = _editTaskViewModel.TaskDetailsFormViewModel;
            var newTask = new TodoTask(_editTaskViewModel.taskId, formViewModel.Title, formViewModel.Deadline);

            try
            {
                await _todoTasksStore.Update(newTask);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
