using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;
using System.Windows.Input;

namespace StudyHelper.WPF.Commands
{
    public class ApplyTimerSettingsCommand : CommandBase
    {
        private readonly TimerSettingsViewModel _timerSettingsViewModel;
        private readonly ModalNavigationStore _modalNavigationStore;

        public ApplyTimerSettingsCommand(TimerSettingsViewModel timerSettingsViewModel,
                                         ModalNavigationStore modalNavigationStore)
        {
             _timerSettingsViewModel = timerSettingsViewModel;
            _modalNavigationStore =    modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            _timerSettingsViewModel.Update();
            _modalNavigationStore.Close(); 
        }
    }
}