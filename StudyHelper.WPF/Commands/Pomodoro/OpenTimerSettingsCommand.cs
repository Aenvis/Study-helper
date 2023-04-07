using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;

namespace StudyHelper.WPF.Commands
{
    public class OpenTimerSettingsCommand : CommandBase
    {
        private readonly PomodoroTimerViewModel _pomodoroTimerViewModel;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenTimerSettingsCommand(PomodoroTimerViewModel pomodoroTimerViewModel, ModalNavigationStore modalNavigationStore)
        {
            _pomodoroTimerViewModel = pomodoroTimerViewModel; 
            _modalNavigationStore = modalNavigationStore;   
        }

        public override void Execute(object? parameter)
        {
            TimerSettingsViewModel timerSettingsViewModel = new TimerSettingsViewModel(_modalNavigationStore, _pomodoroTimerViewModel);
            timerSettingsViewModel.SetTimeString = $"{_pomodoroTimerViewModel.Timer.TimeInMinutes}";
            _modalNavigationStore.CurrentViewModel = timerSettingsViewModel;
        }
    }
}
