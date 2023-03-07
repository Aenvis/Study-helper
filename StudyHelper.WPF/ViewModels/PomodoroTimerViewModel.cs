using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Models;
using StudyHelper.WPF.Stores;
using StudyHelper.WPF.Tools;
using System.Windows.Input; 

namespace StudyHelper.WPF.ViewModels
{
    public class PomodoroTimerViewModel : ViewModelBase
    {
        private  TimerModel _timer;

        public ICommand? StartTimeCommand { get; }
        public ICommand? PauseTimeCommand { get; }
        public ICommand? ResetTimeCommand { get; }
        public ICommand? OpenTimerSettingsCommand { get; }

        public PomodoroTimerViewModel(ModalNavigationStore modalNavigationStore, PomodoroSessionStore pomodoroSessionStore, PomodoroTimer pomodoroTimer)
        {
            
        }

    }
}

