using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Stores;
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

        private string _setTimeDisplay;
        public string SetTimeDisplay
        {
            get => _pomodoroTimerViewModel.SetTime.ToString();
            set
            {
                _setTimeDisplay = value;

                try
                {
                    _pomodoroTimerViewModel.SetTime = Int32.Parse(_setTimeDisplay);
                    OnPropertyChanged(nameof(SetTimeDisplay));
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        public TimerSettingsViewModel(PomodoroTimerViewModel pomodoroTimerViewModel, ModalNavigationStore modalNavigationStore)
        {
            EditTimerSettingsCommand = new EditTimerSettingsCommand(modalNavigationStore);
            CloseModalCommand = new CloseModalCommand(modalNavigationStore);
            _pomodoroTimerViewModel = pomodoroTimerViewModel;
        }
    }
}
