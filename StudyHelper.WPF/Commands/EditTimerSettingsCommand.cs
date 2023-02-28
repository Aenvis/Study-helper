using StudyHelper.WPF.Stores;
using StudyHelper.WPF.Tools;
using StudyHelper.WPF.ViewModels;
using System.Windows.Input;

namespace StudyHelper.WPF.Commands
{
    public class EditTimerSettingsCommand : CommandBase
    {
        private readonly TimerSettingsViewModel _timerSettingsViewModel;
        private readonly PomodoroSessionStore _pomodoroSessionStore;
        private ModalNavigationStore _modalNavigationStore;

        public EditTimerSettingsCommand(TimerSettingsViewModel timerSettingsViewModel,
                                        ModalNavigationStore modalNavigationStore)
        {
             _timerSettingsViewModel = timerSettingsViewModel;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            
            _modalNavigationStore.Close();
        }
    }
}