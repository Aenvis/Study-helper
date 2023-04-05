using StudyHelper.Domain.Models;
using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyHelper.WPF.Commands
{
    public class AddNewTaskCommand : AsyncCommandBase
    {
        private readonly AddNewTaskViewModel _addNewTaskViewModel;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly TodoTasksStore _todoTasksStore;

        public AddNewTaskCommand(AddNewTaskViewModel addNewTaskViewModel, ModalNavigationStore modalNavigationStore, TodoTasksStore todoTasksStore)
        {
            _addNewTaskViewModel = addNewTaskViewModel;
            _modalNavigationStore = modalNavigationStore;
            _todoTasksStore = todoTasksStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            var formViewModel = _addNewTaskViewModel.TaskDetailsFormViewModel;
            var newTask = new TodoTask(Guid.NewGuid(), formViewModel.Title, formViewModel.Deadline);

            try
            {
                await _todoTasksStore.Create(newTask);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
