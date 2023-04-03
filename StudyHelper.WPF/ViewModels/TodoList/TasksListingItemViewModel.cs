using StudyHelper.Domain.Models;
using StudyHelper.WPF.Stores;
using System.Windows.Input;

namespace StudyHelper.WPF.ViewModels
{
    public class TasksListingItemViewModel : ViewModelBase
    {
        public TodoTask Task { get; private set; }
        public string? Title => Task.Title;
        public string? Deadline => Task.Deadline?.ToString("dd/MM");

        public ICommand? OpenEditTaskCommand { get; }

        public TasksListingItemViewModel(TodoTask task, ModalNavigationStore modalNavigationStore)
        {
            Task = task;
           // OpenEditTaskCommand = new OpenEditTaskCommand(modalNavigationStore);
        }
    }
}
