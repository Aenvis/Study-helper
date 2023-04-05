using Microsoft.EntityFrameworkCore.Update.Internal;
using StudyHelper.Domain.Models;
using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Commands.TodoList;
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
        public ICommand? DeleteTaskCommand { get; }

        public TasksListingItemViewModel(TodoTask task, ModalNavigationStore modalNavigationStore, TodoTasksStore todoTasksStore)
        {
            TodoTask = task;
            DeleteTaskCommand = new DeleteTaskCommand(TodoTask.Id, todoTasksStore);
            OpenEditTaskCommand = new OpenEditTaskCommand(this, modalNavigationStore, todoTasksStore);
        }

        public void Update(TodoTask task)
        {
            TodoTask = task;
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Deadline));
        }
    }
}
