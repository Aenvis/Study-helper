﻿using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Stores;
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
            EditTimerSettingsCommand = new ApplyTimerSettingsCommand(this, modalNavigationStore);
            CloseModalCommand = new CloseModalCommand(modalNavigationStore);
            _pomodoroTimerViewModel = pomodoroTimerViewModel;
        }

        public void Update()
        {
            if (int.TryParse(SetTimeString, out int timeInMinutes)) _pomodoroTimerViewModel.UpdatePomodoroTime(timeInMinutes);
        }

    }
}
