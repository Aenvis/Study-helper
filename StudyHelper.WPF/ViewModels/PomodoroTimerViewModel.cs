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
        private const float _maxSeconds = 59f;

        private float _setTime;
        public float SetTime
        {
            get => _setTime;
            set
            {
                _setTime = value;
                CurrentTimeInMinutes = SetTime;
            }
        }

        private float _currentTimeInMinutes;
        public float CurrentTimeInMinutes
        {
            get => _currentTimeInMinutes;
            private set
            {
                _currentTimeInMinutes = value;
                OnPropertyChanged(nameof(CurrentTimeDisplay));
            }
        }

        private float _currentTimeInSeconds;
        public float CurrentTimeInSeconds
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
        public ICommand? OpenTimerSettingsCommand { get; }

        private readonly DispatcherTimer _timer;

        public PomodoroTimerViewModel(ModalNavigationStore modalNavigationStore)
        {
            StartTimeCommand = new StartTimeCommand(this);
            PauseTimeCommand = new PauseTimeCommand(this);
            OpenTimerSettingsCommand = new OpenTimerSettingsCommand(modalNavigationStore);

            IsCounting = true;
            SetTime = 1;

            _timer = new();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (!IsCounting)
            {
                _timer.Stop();
                return;
            }

            CurrentTimeInSeconds--;
            if (CurrentTimeInSeconds <= 0f)
            {
                CurrentTimeInMinutes--;
                CurrentTimeInSeconds = _maxSeconds;
            }

            if(CurrentTimeInMinutes < 0f)
            {
                IsCounting = false;
                CurrentTimeInMinutes = SetTime;
                CurrentTimeInSeconds = 0f;
            }
            
        }
    }
}

