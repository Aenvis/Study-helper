using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyHelper.WPF.ViewModels.TodoList
{
    public class TodoListViewModel : ViewModelBase
    {
        public TasksListingViewModel TasksListingViewModel { get; set; }

        public ICommand? OpenNewTaskCommand { get; }

        public TodoListViewModel(ModalNavigationStore modalNavigationStore)
        {
            TasksListingViewModel = new TasksListingViewModel(modalNavigationStore);
            OpenNewTaskCommand = new OpenNewTaskCommand(modalNavigationStore);
        }
    }
}
