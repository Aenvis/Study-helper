using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands
{
    public class OpenTimerSettingsCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenTimerSettingsCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;   
        }

        public override void Execute(object? parameter)
        {
            TimerSettingsViewModel timerSettingsViewModel = new TimerSettingsViewModel();
            _modalNavigationStore.CurrentViewModel = timerSettingsViewModel;
        }
    }
}
