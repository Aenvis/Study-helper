﻿using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands
{
    class PauseTimeCommand : CommandBase
    {
        private readonly PomodoroTimerViewModel _pomodoroTimerViewModel;

        public PauseTimeCommand(PomodoroTimerViewModel pomodoroTimerViewModel)
        {
            _pomodoroTimerViewModel = pomodoroTimerViewModel;
        }

        public override void Execute(object? parameter)
        {
           _pomodoroTimerViewModel.IsCounting = false;
        }
    }
}
