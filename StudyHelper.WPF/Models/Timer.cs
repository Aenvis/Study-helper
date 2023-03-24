using System;
using System.Windows.Threading;

namespace StudyHelper.WPF.Models
{
    public enum TimerState
    {
        Running,
        Paused,
        Stopped
    }

    public class Timer
    {
        private readonly DispatcherTimer _timer;

        private int _secondsLeft;
        private int _timeInMinutes;

        public int TimeInMinutes
        {
            get => _timeInMinutes;
            set
            {
                _timeInMinutes = value;
                OnSetTimeChanged?.Invoke();
            }
        }

        public TimerState State { get; set; }

        public string TimeDisplay => TimeSpan.FromSeconds(_secondsLeft).ToString("m\\:ss");

        public event Action? OnSetTimeChanged;
        public event Action? OnTimerUpdate;

        public Timer()
        {
            // built-in timer functionality
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0,0,1);
            _timer.Tick += OnTimerTick;
           
            //hardcoded set time and initial seconds calculation
            TimeInMinutes = 2;
            _secondsLeft = TimeInMinutes * 60;

            //initial clock state
            State = TimerState.Stopped;
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            if (_secondsLeft > 0)
            {
                _secondsLeft--;
                OnTimerUpdate?.Invoke();
            }
            else Stop();
        }

        public void Start() 
        {
            if(State == TimerState.Stopped)
            {
                _secondsLeft = TimeInMinutes * 60;
                _timer.Start();
            }
            else if(State == TimerState.Paused)
            {
                _timer.Start();
            }

            State = TimerState.Running;
        }

        public void Pause()
        {
            _timer.Stop();
            State = TimerState.Paused;
        }

        public void Stop()
        {
            _timer.Stop();
            State = TimerState.Stopped;
        }
    }
}
