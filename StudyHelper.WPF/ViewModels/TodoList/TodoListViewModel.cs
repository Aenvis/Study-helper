using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.ViewModels.TodoList
{
    public class TodoListViewModel : ViewModelBase
    {
        public TasksListingViewModel TasksListingViewModel { get; set; }

        public TodoListViewModel()
        {
            TasksListingViewModel = new TasksListingViewModel();
        }
    }
}
