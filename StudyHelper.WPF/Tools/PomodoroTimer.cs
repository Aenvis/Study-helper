﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace StudyHelper.WPF.Tools
{
    /// <summary>
    /// Internal wrapper class for DispatcherTimer to manage pomodoro cycles
    /// </summary>
    public class PomodoroTimer
    {
        private readonly DispatcherTimer _timer;

        private int _currentSeconds;
        public int CurrentSeconds
        {
            get => _currentSeconds;
            set
            {
                _currentSeconds = value;
            }
        }
        public int SetMinutes
        {
            get => _currentSeconds * 60;
            set
            {
                _currentSeconds = value * 60;
            }
        }

        public event Action? OnTimerCompleted;

        public PomodoroTimer()
        {
            CurrentSeconds = 25 * 60;

            //instantiate _timer here instead of as a singleton in generic host because there won't be any other _timer in the application, and the host builder is messy enough
            _timer = new();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += Timer_Tick;

            Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (_currentSeconds > 0)
            {
                _currentSeconds--;
            }
            else
            {
                OnTimerCompleted?.Invoke();
                Stop();
            }
        }

        public void Start() => _timer.Start();
        public void Stop() => _timer.Stop();
    }
}
