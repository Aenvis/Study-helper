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
        private readonly PomodoroSessionStore _pomodoroSessionStore;

        private  PomodoroTimer _timer;

        public string CurrentTimeDisplay
        {
            get => TimeFormatConverter.SecondsToMmSsString(_timer.CurrentSeconds);
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
            _timer = pomodoroTimer;
            StartTimeCommand = new StartTimeCommand(_timer);
            PauseTimeCommand = new PauseTimeCommand(_timer);
            OpenTimerSettingsCommand = new OpenTimerSettingsCommand(pomodoroSessionStore, modalNavigationStore);

            _pomodoroSessionStore = pomodoroSessionStore;

            _pomodoroSessionStore.OnPomodoroTimeUpdated += PomodoroSessionStore_OnPomodoroTimeUpdated;
            _timer.SetMinutes = _pomodoroSessionStore.SetTime;
        }

        public override void Dispose()
        {
            _pomodoroSessionStore.OnPomodoroTimeUpdated -= PomodoroSessionStore_OnPomodoroTimeUpdated;
            base.Dispose();
        }

        private void PomodoroSessionStore_OnPomodoroTimeUpdated(int param)
        {
            _timer.SetMinutes = param;
        }
    }
}

