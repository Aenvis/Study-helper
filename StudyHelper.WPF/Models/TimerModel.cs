using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace StudyHelper.WPF.Models
{
    internal enum TimerState
    {
        Running,
        Paused,
        Stopped
    }

    internal class TimerModel
    {
        private readonly DispatcherTimer _timer;
        private int _timeInSeconds;
        private TimerState _state;

        public int TimeInMinutes { get; set; }

        public TimerModel()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += OnTimerTick;
            TimeInMinutes = 25;
            _timeInSeconds = TimeInMinutes * 60;

            _state = TimerState.Stopped;
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            if (_timeInSeconds < 0)
                _timeInSeconds--;
            else Stop();
        }

        public void Start() 
        {
            if (_timer is null) return;

            if(_state == TimerState.Stopped)
            {
                _timeInSeconds = TimeInMinutes * 60;
                _timer.Start();
            }
            else if(_state == TimerState.Paused)
            {
                _timer.Start();
            }

            SetState(TimerState.Running);
        }

        public void Pause()
        {
            _timer.Stop();
            SetState(TimerState.Paused);
        }

        public void Stop()
        {
            _timer.Stop();
            SetState(TimerState.Stopped);
        }

        public void SetState(TimerState state) => _state = state; 
    }
}
