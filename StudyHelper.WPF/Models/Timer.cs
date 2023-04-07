using System;
using System.Windows.Threading;

namespace StudyHelper.WPF.Models
{
    public enum BreakTime
    {
        Short = 5,
        Long = 15
    }
    public enum TimerState
    {
        Running,
        Paused,
        // for proper pomodoro cycle,
        // break occurs everytime the timer counts down to 0 seconds;
        // it's different from pause or stop in such a way that pause and
        // stop are caused by the user, and break is caused by the logic and rules of pomodoro
        Break, 
        Stopped
    }

    public class Timer
    {
        private readonly DispatcherTimer _timer;

        private int _secondsLeft;
        private int _timeInMinutes;

        private const int _maxCycle = 4;
        private int _cycle = 1;

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

        public string TimeDisplay => State == TimerState.Stopped ? TimeSpan.FromSeconds(TimeInMinutes * 60).ToString("m\\:ss")
                                                                 : TimeSpan.FromSeconds(_secondsLeft).ToString("m\\:ss");

        public event Action? OnSetTimeChanged;
        public event Action? OnTimerUpdate;

        public Timer()
        {
            // built-in timer functionality
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0,0,1);
            _timer.Tick += OnTimerTick;
           
            //hardcoded set time and initial seconds calculation
            TimeInMinutes = 25;
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
            else
            {
                Pause();
                OnCycleUpdate();
            }
        }

        public void Start() 
        {
            _timer.Start();
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
            //Stop completely resets pomodoro
            _cycle = 1;
            _secondsLeft = TimeInMinutes * 60;
            State = TimerState.Stopped;
        }

        private void OnCycleUpdate()
        {
            System.Diagnostics.Debug.WriteLine(_cycle);

            if (_cycle < _maxCycle)
                TimeInMinutes = (int)BreakTime.Short;
            else
            {
                TimeInMinutes = (int)BreakTime.Long;
                _cycle = 1;
            }
            _cycle++;
            _secondsLeft = TimeInMinutes * 60;
            Start();
        }
    }
}
