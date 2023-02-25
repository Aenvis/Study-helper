using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands
{
    public class StartTimeCommand : CommandBase
    {
        private readonly PomodoroTimerViewModel _pomodoroTimerViewModel;

        public StartTimeCommand(PomodoroTimerViewModel pomodoroTimerViewModel)
        {
            _pomodoroTimerViewModel = pomodoroTimerViewModel;
        }

        public override void Execute(object? parameter)
        {
           _pomodoroTimerViewModel.IsCounting = true;
        }
    }
}
