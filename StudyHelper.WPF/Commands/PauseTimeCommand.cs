using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands
{
    class PauseTimeCommand : CommandBase
    {
        private readonly PomodoroViewModel _pomodoroViewModel;

        public PauseTimeCommand(PomodoroViewModel pomodoroViewModel)
        {
            _pomodoroViewModel = pomodoroViewModel;
        }

        public override void Execute(object? parameter)
        {
            _pomodoroViewModel.IsCounting = false;
        }
    }
}
