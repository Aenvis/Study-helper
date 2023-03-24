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
        private readonly PomodoroTimerViewModel _pomodoroTimerViewModel;
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

        public TimerSettingsViewModel(ModalNavigationStore modalNavigationStore, PomodoroTimerViewModel pomodoroTimerViewModel)
        {
            EditTimerSettingsCommand =  new ApplyTimerSettingsCommand(this, modalNavigationStore);
            CloseModalCommand        =  new CloseModalCommand(modalNavigationStore);
            _pomodoroTimerViewModel = pomodoroTimerViewModel;
        }

        public void Update()
        {
            if (Int32.TryParse(SetTimeString, out int timeInMinutes)) _pomodoroTimerViewModel.UpdatePomodoroTime(timeInMinutes);
        }
        
    }
}
