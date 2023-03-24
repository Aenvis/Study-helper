using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Models;
using StudyHelper.WPF.Stores;
using StudyHelper.WPF.Tools;
using System.Windows.Input; 

namespace StudyHelper.WPF.ViewModels
{
    public class PomodoroTimerViewModel : ViewModelBase
    {
        private  Timer _timer;

        public string TimeDisplay => _timer.TimeDisplay;

        public ICommand? StartTimeCommand { get; }
        public ICommand? PauseTimeCommand { get; }
        public ICommand? StopTimeCommand { get; }
        public ICommand? OpenTimerSettingsCommand { get; }

        public PomodoroTimerViewModel(ModalNavigationStore modalNavigationStore)
        {
            _timer = new Timer();
            StartTimeCommand = new StartTimeCommand(_timer); 
            PauseTimeCommand = new PauseTimeCommand(_timer); 
            StopTimeCommand = new StopTimeCommand(_timer);
            OpenTimerSettingsCommand = new OpenTimerSettingsCommand(this, modalNavigationStore);

            _timer.OnSetTimeChanged += Timer_OnSetTimeChanged;
            _timer.OnTimerUpdate += _timer_OnTimerUpdate;
        }

        private void Timer_OnSetTimeChanged()
        {
            if(_timer.State == TimerState.Stopped)
                OnPropertyChanged(nameof(TimeDisplay));
        }

        private void _timer_OnTimerUpdate()
        {
            if (_timer.State == TimerState.Running)
                OnPropertyChanged(nameof(TimeDisplay));
        }
    
        public void UpdatePomodoroTime(int timeInMinutes)
        {
            _timer.TimeInMinutes = timeInMinutes;
            if (_timer.State == TimerState.Stopped)
                OnPropertyChanged(nameof(TimeDisplay));
        }
    }
}

