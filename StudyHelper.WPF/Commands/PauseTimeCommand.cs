using StudyHelper.WPF.Models;
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
        private readonly Timer _timer;

        public PauseTimeCommand(Timer timer)
        {
            _timer = timer;
        }

        public override void Execute(object? parameter)
        {
            _timer.Pause();
        }
    }
}
