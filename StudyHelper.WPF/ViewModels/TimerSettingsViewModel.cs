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

        private string? _setTimeString;
        public string? SetTimeString
        {
            get => _setTimeString;
            set
            {
                _setTimeString = value;
                OnPropertyChanged(SetTimeString);
            }
        }

        public TimerSettingsViewModel(PomodoroSessionStore pomodoroSessionStore, ModalNavigationStore modalNavigationStore)
        {
            EditTimerSettingsCommand = new EditTimerSettingsCommand(this, modalNavigationStore);
            CloseModalCommand = new CloseModalCommand(modalNavigationStore);

            _pomodoroSessionStore = pomodoroSessionStore;
            SetTimeString = _pomodoroSessionStore.SetTime.ToString();
        }

        public void Update()
        {
            _pomodoroSessionStore.Update(!string.IsNullOrEmpty(SetTimeString) ? 
                                                                            int.Parse(SetTimeString) :
                                                                            _pomodoroSessionStore.SetTime);
        }
    }
}
