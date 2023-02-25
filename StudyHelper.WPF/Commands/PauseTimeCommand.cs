using StudyHelper.WPF.Tools;
using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands
{
    public class PauseTimeCommand : CommandBase
    {
        private readonly PomodoroTimer _pomodoroTimer;

        public PauseTimeCommand(PomodoroTimer pomodoroTimer)
        {
            _pomodoroTimer = pomodoroTimer;
        }

        public override void Execute(object? parameter)
        {
            //  _pomodoroTimerViewModel.IsCounting = false;
        }
    }
}
