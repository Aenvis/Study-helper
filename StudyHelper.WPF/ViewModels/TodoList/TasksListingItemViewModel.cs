using Microsoft.EntityFrameworkCore.Update.Internal;
using StudyHelper.Domain.Models;
using StudyHelper.WPF.Stores;
using System.Windows.Input;

namespace StudyHelper.WPF.ViewModels
{
    public class TasksListingItemViewModel : ViewModelBase
    {
        public TodoTask TodoTask { get; private set; }
        public string? Title => TodoTask.Title;
        public string? Deadline => TodoTask.Deadline?.ToString("dd/MM");

        public ICommand? OpenEditTaskCommand { get; }

        public TasksListingItemViewModel(TodoTask task, ModalNavigationStore modalNavigationStore)
        {
            TodoTask = task;
           // OpenEditTaskCommand = new OpenEditTaskCommand(modalNavigationStore);
        }

        public void Update(TodoTask task)
        {
            TodoTask = task;
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Deadline));
        }
    }
}
