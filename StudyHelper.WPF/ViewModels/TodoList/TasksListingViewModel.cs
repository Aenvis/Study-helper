using StudyHelper.Domain.Models;
using StudyHelper.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StudyHelper.WPF.ViewModels
{
    public class TasksListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TasksListingItemViewModel>? _tasksListingItemViewModels;
        private readonly ModalNavigationStore _modalNavigationStore;

        public IEnumerable<TasksListingItemViewModel>? TasksListingItemViewModels => _tasksListingItemViewModels;

        public TasksListingViewModel(ModalNavigationStore modalNavigationStore)
        {
            _tasksListingItemViewModels = new ObservableCollection<TasksListingItemViewModel>();
            _modalNavigationStore = modalNavigationStore;
            #if DEBUG
            TEST();
            #endif
        }

        private void TEST()
        {
            TodoTask task0 = new TodoTask(Guid.NewGuid(), "Read the article", new DateTime(2024, 12, 31));
            TodoTask task1 = new TodoTask(Guid.NewGuid(), "Read the article", new DateTime(2024, 12, 31));
            TodoTask task2 = new TodoTask(Guid.NewGuid(), "Read the article", new DateTime(2024, 12, 31));
            TodoTask task3 = new TodoTask(Guid.NewGuid(), "Read the article");
            TodoTask task4 = new TodoTask(Guid.NewGuid(), "Read the article");
            _tasksListingItemViewModels.Add(new TasksListingItemViewModel(task0, _modalNavigationStore));
            _tasksListingItemViewModels.Add(new TasksListingItemViewModel(task1, _modalNavigationStore));
            _tasksListingItemViewModels.Add(new TasksListingItemViewModel(task2, _modalNavigationStore));
            _tasksListingItemViewModels.Add(new TasksListingItemViewModel(task3, _modalNavigationStore));
            _tasksListingItemViewModels.Add(new TasksListingItemViewModel(task4, _modalNavigationStore));
        }
    }
}
