using StudyHelper.WPF.Models;

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
