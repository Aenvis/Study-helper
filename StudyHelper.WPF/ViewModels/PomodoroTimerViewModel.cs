using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Stores;
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
        // displaying time in mm : ss format
        private const int _maxSeconds = 59;

        private readonly PomodoroSessionStore _pomodoroSessionStore;

        private int _setTime;
        public int SetTime
        {
            get => _setTime;
            set
            {
                _setTime = value;
            }
        }

        private int _currentTimeInMinutes;
        public int CurrentTimeInMinutes
        {
            get => _currentTimeInMinutes;
            private set
            {
                _currentTimeInMinutes = value;
                OnPropertyChanged(nameof(CurrentTimeDisplay));
            }
        }

        private int _currentTimeInSeconds;
        public int CurrentTimeInSeconds
        {
            get => _currentTimeInSeconds;
            set
            {
                _currentTimeInSeconds = value;
                OnPropertyChanged(nameof(CurrentTimeDisplay));
            }
        }

        public string CurrentTimeDisplay => (CurrentTimeInSeconds >= 10) ?
            $"{CurrentTimeInMinutes} : {CurrentTimeInSeconds}" :
            $"{CurrentTimeInMinutes} : 0{CurrentTimeInSeconds}";

        public bool IsCounting { get; set; }

        public ICommand? StartTimeCommand { get; }
        public ICommand? PauseTimeCommand { get; }
        public ICommand? ResetTimeCommand { get; }
        public ICommand? OpenTimerSettingsCommand { get; }

        private readonly DispatcherTimer _timer;

        public PomodoroTimerViewModel(ModalNavigationStore modalNavigationStore, PomodoroSessionStore pomodoroSessionStore)
        {
            StartTimeCommand = new StartTimeCommand(this);
            PauseTimeCommand = new PauseTimeCommand(this);
            OpenTimerSettingsCommand = new OpenTimerSettingsCommand(this, modalNavigationStore);

            _pomodoroSessionStore = pomodoroSessionStore;

            SetTime = 1;
            CurrentTimeInMinutes = SetTime;

            _timer = new();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (!IsCounting)
            {
                return;
            }

            CurrentTimeInSeconds--;

            if (CurrentTimeInSeconds <= 0)
            {
                CurrentTimeInMinutes--;
            
                if (CurrentTimeInMinutes < 0)
                {
                    OnCycleEnd();
                }

                CurrentTimeInSeconds = _maxSeconds;
            }
        }

        private void OnCycleEnd()
        {
            _pomodoroSessionStore.IncrementCycleCount();
            CurrentTimeInMinutes = _pomodoroSessionStore.GetBreakTime() - 1;
        }
    }
}

