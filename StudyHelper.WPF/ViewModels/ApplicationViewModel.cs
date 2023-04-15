using StudyHelper.WPF.ViewModels.MoodAnalyser;
using StudyHelper.WPF.ViewModels.TodoList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public PomodoroViewModel PomodoroViewModel { get; }
        public TodoListViewModel TodoListViewModel{ get; }
        public MoodAnalysisViewModel MoodAnalysisViewModel { get; }

        public ApplicationViewModel(PomodoroViewModel pomodoroViewModel, TodoListViewModel todoListViewModel, MoodAnalysisViewModel moodAnalysisViewModel)
        {
            PomodoroViewModel = pomodoroViewModel;
            TodoListViewModel = todoListViewModel;
            MoodAnalysisViewModel = moodAnalysisViewModel;
        }
    }
}
