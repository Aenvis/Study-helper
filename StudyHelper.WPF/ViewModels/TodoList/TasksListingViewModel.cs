using StudyHelper.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudyHelper.WPF.ViewModels
{
    public class TasksListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TasksListingItemViewModel>? _tasksListingItemViewModels;

        public IEnumerable<TasksListingItemViewModel>? TasksListingItemViewModels => _tasksListingItemViewModels;

        public TasksListingViewModel()
        {
            _tasksListingItemViewModels = new ObservableCollection<TasksListingItemViewModel>();
            #if DEBUG
            TEST();
            #endif
        }

        private void TEST()
        {
            TodoTask task0 = new TodoTask(Guid.NewGuid(), "Read the article", new DateTime(2024, 12, 31));
            TodoTask task1 = new TodoTask(Guid.NewGuid(), "Read the article", new DateTime(2024, 12, 31));
            TodoTask task2 = new TodoTask(Guid.NewGuid(), "Read the article", new DateTime(2024, 12, 31));
            TodoTask task3 = new TodoTask(Guid.NewGuid(), "Read the article", new DateTime(2024, 12, 31));
            TodoTask task4 = new TodoTask(Guid.NewGuid(), "Read the article", new DateTime(2024, 12, 31));
            _tasksListingItemViewModels.Add(new TasksListingItemViewModel(task0));
            _tasksListingItemViewModels.Add(new TasksListingItemViewModel(task1));
            _tasksListingItemViewModels.Add(new TasksListingItemViewModel(task2));
            _tasksListingItemViewModels.Add(new TasksListingItemViewModel(task3));
            _tasksListingItemViewModels.Add(new TasksListingItemViewModel(task4));
        }
    }
}
