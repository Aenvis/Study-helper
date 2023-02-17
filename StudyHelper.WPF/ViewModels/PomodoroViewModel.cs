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
        private float _setTime;
        public float SetTime
        {
            get => _setTime;
            set
            {
                _setTime = value;
                CurrentTime = SetTime;
            }
        }


        private float _currentTime;
        public float CurrentTime
        {
            get => _currentTime;
            private set
            {
                _currentTime = value;
                OnPropertyChanged(nameof(CurrentTimeDisplay));
            }
        }

        public string CurrentTimeDisplay => CurrentTime.ToString();

        private readonly DispatcherTimer timer;

        public PomodoroViewModel()
        {
            CurrentTime = 15;

            timer = new();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (CurrentTime <= 0)
            {
                timer.Stop();
                return;
            }

            CurrentTime--;  
        }
    }
}
