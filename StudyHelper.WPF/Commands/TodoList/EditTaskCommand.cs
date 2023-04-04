using StudyHelper.Domain.Models;
using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands.TodoList
{
    internal class EditTaskCommand : AsyncCommandBase
    {
        private readonly AddNewTaskViewModel _addNewTaskViewModel;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly TodoTasksStore _todoTasksStore;

        public EditTaskCommand(AddNewTaskViewModel addNewTaskViewModel, ModalNavigationStore modalNavigationStore, TodoTasksStore todoTasksStore)
        {
            _addNewTaskViewModel = addNewTaskViewModel;
            _modalNavigationStore = modalNavigationStore;
            _todoTasksStore = todoTasksStore;
        }

        public override void Execute(object? parameter)
        {
            var formViewModel = _addNewTaskViewModel.TaskDetailsFormViewModel;
            var newTask = new TodoTask(Guid.NewGuid(), formViewModel.Title, formViewModel.Deadline);

            _todoTasksStore.Create(newTask);
            _modalNavigationStore.Close();
        }

        public override Task ExecuteAsync(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
