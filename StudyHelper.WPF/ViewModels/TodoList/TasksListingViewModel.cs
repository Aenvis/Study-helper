using StudyHelper.Domain.Models;
using StudyHelper.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

            _todoTasksStore.TodoTasksLoaded += TodoTasksStore_TodoTasksLoaded;
            _todoTasksStore.TodoTaskCreated += TodoTasksStore_TodoTaskCreated;
            _todoTasksStore.TodoTaskUpdated += TodoTasksStore_TodoTaskUpdated;
            _todoTasksStore.TodoTaskDeleted += TodoTasksStore_TodoTaskDeleted;
        }

        public override void Dispose()
        {
            base.Dispose();

            _todoTasksStore.TodoTasksLoaded -= TodoTasksStore_TodoTasksLoaded;
            _todoTasksStore.TodoTaskCreated -= TodoTasksStore_TodoTaskCreated;
            _todoTasksStore.TodoTaskUpdated -= TodoTasksStore_TodoTaskUpdated;
            _todoTasksStore.TodoTaskDeleted -= TodoTasksStore_TodoTaskDeleted;
        }

        private void TodoTasksStore_TodoTasksLoaded()
        {
            _tasksListingItemViewModels.Clear();

            foreach(var task in _todoTasksStore.TodoTasks)
            {
                AddTask(task);
            }
        }

        private void TodoTasksStore_TodoTaskCreated(TodoTask task)
        {
            AddTask(task);
        }

        private void TodoTasksStore_TodoTaskUpdated(TodoTask task)
        {
            var taskViewModel = _tasksListingItemViewModels.FirstOrDefault(x => x.TodoTask.Id == task.Id);

            if (taskViewModel == null) return;

            taskViewModel.Update(task);
        }

        private void TodoTasksStore_TodoTaskDeleted(Guid id)
        {
            var taskViewModel = _tasksListingItemViewModels.FirstOrDefault(x => x.TodoTask.Id == id);

            if (taskViewModel == null) return;

            _tasksListingItemViewModels.Remove(taskViewModel);
        }

        private void AddTask(TodoTask task)
        {
            var newTask = new TasksListingItemViewModel(task, _modalNavigationStore);
            _tasksListingItemViewModels.Add(newTask);
        }
    }
}
