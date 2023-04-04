using StudyHelper.Domain.Models;
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
    public class EditTaskViewModel : ViewModelBase
    {
        public TaskDetailsFormViewModel TaskDetailsFormViewModel { get; }

        public Guid taskId { get; }

        public EditTaskViewModel(TodoTask task, ModalNavigationStore modalNavigationStore, TodoTasksStore todoTasksStore)
        {
            taskId = task.Id;
            ICommand submitCommand = new EditTaskCommand(this, modalNavigationStore, todoTasksStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);

            TaskDetailsFormViewModel = new TaskDetailsFormViewModel(submitCommand, cancelCommand)
            {
                Title = task.Title,
                Deadline = task.Deadline
            };
        }
    }
}
