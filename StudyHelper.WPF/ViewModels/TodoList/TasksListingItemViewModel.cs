using StudyHelper.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.ViewModels
{
    public class TasksListingItemViewModel : ViewModelBase
    {
        public TodoTask Task { get; private set; }
        public string? Title => Task.Title;
        public string? Deadline => Task.Deadline?.ToString("dd/MM");

        public TasksListingItemViewModel(TodoTask task)
        {
            Task = task;
        }
    }
}
