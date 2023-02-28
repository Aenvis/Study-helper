using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Stores;
using StudyHelper.WPF.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace StudyHelper.WPF.ViewModels
{
    public class PomodoroTimerViewModel : ViewModelBase
    {
        private readonly PomodoroTimer timer;

        public string CurrentTimeDisplay
        {
            get => TimeFormatConverter.SecondsToMmSsString(timer.Seconds);
            private set
            {
                OnPropertyChanged(nameof(CurrentTimeDisplay));
            }
        }
        
        public ICommand? StartTimeCommand { get; }
        public ICommand? PauseTimeCommand { get; }
        public ICommand? ResetTimeCommand { get; }
        public ICommand? OpenTimerSettingsCommand { get; }

        public PomodoroTimerViewModel(ModalNavigationStore modalNavigationStore, PomodoroSessionStore pomodoroSessionStore, PomodoroTimer pomodoroTimer)
        {
            timer = pomodoroTimer;
            StartTimeCommand = new StartTimeCommand(timer);
            PauseTimeCommand = new PauseTimeCommand(timer);
            OpenTimerSettingsCommand = new OpenTimerSettingsCommand(pomodoroSessionStore, modalNavigationStore);
        }    
    }
}

