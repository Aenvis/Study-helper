using StudyHelper.WPF.Models;

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
