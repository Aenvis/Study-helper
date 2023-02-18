using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace StudyHelper.WPF.ViewModels
{
    public class PomodoroViewModel : ViewModelBase
    {
        // displaying time in mm : ss format
        private const float _maxSeconds = 59f;
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

        public string CurrentTimeDisplay => (CurrentTimeInSeconds >= 10) ?
            $"{CurrentTimeInMinutes} : {CurrentTimeInSeconds}" :
            $"{CurrentTimeInMinutes} : 0{CurrentTimeInSeconds}";

        public bool IsCounting { get; set; } 

        private readonly DispatcherTimer timer;

        public PomodoroViewModel()
        {
            IsCounting = true;
            CurrentTimeInMinutes = 15;

            timer = new();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (!IsCounting)
            {
                timer.Stop();
                return;
            }
            
            CurrentTimeInSeconds--;
            if(CurrentTimeInSeconds <= 0)
            {
                CurrentTimeInMinutes--;
                CurrentTimeInSeconds = _maxSeconds;
            }
        }
    }
}
