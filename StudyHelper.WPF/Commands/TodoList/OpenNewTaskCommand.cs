using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands
{
    public class OpenNewTaskCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly TodoTasksStore _todoTasksStore;

        public OpenNewTaskCommand(ModalNavigationStore modalNavigationStore, TodoTasksStore todoTasksStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _todoTasksStore = todoTasksStore;
        }
        public override void Execute(object? parameter)
        {
            var addNewTaskViewModel = new AddNewTaskViewModel(_modalNavigationStore, _todoTasksStore);
            _modalNavigationStore.CurrentViewModel = addNewTaskViewModel;
        }
    }
}
