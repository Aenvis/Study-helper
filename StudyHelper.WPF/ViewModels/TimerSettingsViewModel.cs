using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Stores;
using StudyHelper.WPF.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyHelper.WPF.ViewModels
{
    public class TimerSettingsViewModel : ViewModelBase
    {
        private readonly PomodoroSessionStore _pomodoroSessionStore;
        public ICommand? EditTimerSettingsCommand { get; }
        public ICommand? CloseModalCommand { get; }

        public string SetTimeString
        {
            set
            {
                OnPropertyChanged();
            }
        }

        public TimerSettingsViewModel(PomodoroSessionStore pomodoroSessionStore, ModalNavigationStore modalNavigationStore)
        {
            EditTimerSettingsCommand = new EditTimerSettingsCommand(this, modalNavigationStore);
            CloseModalCommand = new CloseModalCommand(modalNavigationStore);

            _pomodoroSessionStore = pomodoroSessionStore;
        }
    }
}
