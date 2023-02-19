using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands
{
    class StartTimeCommand : CommandBase
    {
        private readonly PomodoroViewModel _pomodoroViewModel;

        public StartTimeCommand(PomodoroViewModel pomodoroViewModel)
        {
            _pomodoroViewModel = pomodoroViewModel;
        }

        public override void Execute(object? parameter)
        {
            _pomodoroViewModel.IsCounting = true;
        }
    }
}
