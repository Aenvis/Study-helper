using StudyHelper.WPF.Stores;
using StudyHelper.WPF.Tools;
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
        private readonly PomodoroSessionStore _pomodoroSessionStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenTimerSettingsCommand(PomodoroSessionStore pomodoroSessionStore, ModalNavigationStore modalNavigationStore)
        {
            _pomodoroSessionStore = pomodoroSessionStore;
            _modalNavigationStore = modalNavigationStore;   
        }

        public override void Execute(object? parameter)
        {
            TimerSettingsViewModel timerSettingsViewModel = new TimerSettingsViewModel(_pomodoroSessionStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = timerSettingsViewModel;
        }
    }
}
