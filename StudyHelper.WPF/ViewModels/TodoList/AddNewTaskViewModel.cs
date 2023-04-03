using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyHelper.WPF.ViewModels
{
    public class AddNewTaskViewModel : ViewModelBase
    {
        public TaskDetailsFormViewModel TaskDetailsFormViewModel { get; }
        public AddNewTaskViewModel(ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand = new AddNewTaskCommand(modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);

            TaskDetailsFormViewModel = new TaskDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
