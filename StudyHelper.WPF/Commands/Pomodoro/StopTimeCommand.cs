using StudyHelper.WPF.Models;
using System;

namespace StudyHelper.WPF.Commands
{
    public class StopTimeCommand : CommandBase
    {
        private readonly Timer _timer;

        public StopTimeCommand(Timer timer)
        {
            _timer = timer;
        }

        public override void Execute(object? parameter)
        {
            _timer.Stop();
        }
    }
}
