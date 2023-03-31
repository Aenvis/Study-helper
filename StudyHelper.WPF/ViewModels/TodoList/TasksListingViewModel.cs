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
            TodoTask task0 = new TodoTask(Guid.NewGuid(), "Read the article", "NILM", new DateOnly(2024, 12, 31));
            _tasksListingItemViewModels.Add(new TasksListingItemViewModel(task0));
        }
    }
}
