using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace StudyHelper.WPF.Models
{
    public enum TimerState
    {
        Running,
        Paused,
        Stopped
    }

    public class TimerModel
    {
        private readonly DispatcherTimer _timer;
        private int _timeInSeconds;
        private int _timeInMinutes;
        private TimerState _state;

        public int TimeInMinutes
        {
            get => _timeInMinutes;
            set
            {
                _timeInMinutes = value;
                OnSetTimeChanged?.Invoke();
            }
        }

        public TimerState State
        {
            get => _state;
            set
            {
                _state = value;
            }
        }
         
        public string TimeDisplay
        {
            get
            { 
                var minutes = _timeInSeconds / 60;
                var seconds = _timeInSeconds % 60;
                var minutesDisplay = minutes > 10 ? minutes.ToString() : $"0{minutes}";
                var secondsDisplay = seconds > 10 ? seconds.ToString() : $"0{seconds}";

                return $"{minutesDisplay} : {secondsDisplay}";
            } 
        }

        public event Action? OnSetTimeChanged;
        public event Action? OnTimerUpdate;

        public TimerModel()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0,0,1);
            _timer.Tick += OnTimerTick;
           
            
            TimeInMinutes = 2;
            _timeInSeconds = TimeInMinutes * 60;

            State = TimerState.Stopped;
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            if (_timeInSeconds > 0)
            {
                _timeInSeconds--;
                OnTimerUpdate?.Invoke();
            }
            else Stop();
        }

        public void Start() 
        {
            if(_state == TimerState.Stopped)
            {
                _timeInSeconds = TimeInMinutes * 60;
                _timer.Start();
            }
            else if(_state == TimerState.Paused)
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
