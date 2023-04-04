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
        private readonly TodoTasksStore _todoTasksStore;

        public IEnumerable<TasksListingItemViewModel>? TasksListingItemViewModels => _tasksListingItemViewModels;

        public TasksListingViewModel(ModalNavigationStore modalNavigationStore, TodoTasksStore todoTasksStore)
        {
            _tasksListingItemViewModels = new ObservableCollection<TasksListingItemViewModel>();
            _modalNavigationStore = modalNavigationStore;
            _todoTasksStore = todoTasksStore;           
        }

    }
}
