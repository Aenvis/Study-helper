using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands
{
    public class OpenEditTaskCommand : CommandBase
    {
        private readonly TasksListingItemViewModel _itemViewModel;

        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly TodoTasksStore _todoTasksStore;

        public OpenEditTaskCommand(TasksListingItemViewModel itemViewModel, ModalNavigationStore modalNavigationStore, TodoTasksStore todoTasksStore)
        {
            _itemViewModel = itemViewModel;
            _modalNavigationStore = modalNavigationStore;
            _todoTasksStore = todoTasksStore;
        }
        public override void Execute(object? parameter)
        {
            var editTaskViewModel = new EditTaskViewModel(_itemViewModel.TodoTask, _modalNavigationStore, _todoTasksStore);
            _modalNavigationStore.CurrentViewModel = editTaskViewModel;
        }
    }
}
