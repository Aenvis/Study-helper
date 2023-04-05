using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Stores;
using System.Windows.Input;

namespace StudyHelper.WPF.ViewModels
{
    public class AddNewTaskViewModel : ViewModelBase
    {
        public TaskDetailsFormViewModel TaskDetailsFormViewModel { get; }
        public AddNewTaskViewModel(ModalNavigationStore modalNavigationStore, TodoTasksStore todoTaskStore)
        {
            ICommand submitCommand = new AddNewTaskCommand(this, modalNavigationStore, todoTaskStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);

            TaskDetailsFormViewModel = new TaskDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
