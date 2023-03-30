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
    public class StartTimeCommand : CommandBase
    {
        private readonly Timer _timer;

        public StartTimeCommand(Timer timer)
        {
            _timer = timer;
        }

        public override void Execute(object? parameter)
        {
            _timer.Start();
        }
    }
}
