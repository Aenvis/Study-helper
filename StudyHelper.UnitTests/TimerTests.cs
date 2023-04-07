using StudyHelper.WPF.Models;
using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;

namespace StudyHelper.WPF.Tests
{
    public class TimerTests
    {
        private Models.Timer _timer;

        private TimerSettingsViewModel _timerSettingsViewModel;
        private PomodoroTimerViewModel _pomodoroTimerViewModel;
        private Mock<ModalNavigationStore> _modalNavigationStoreMock;

        [SetUp]
        public void Setup()
        {
            _timer = new Models.Timer();
        }

        [Test]
        public void Timer_Start_TimerStateIsRunning()
        {
            var expectedState = TimerState.Running;

            _timer.Start();

            Assert.That(_timer.State, Is.EqualTo(expectedState));
        }

        [Test]
        public void Timer_Pause_TimerStateIsPaused()
        {
            var expectedState = TimerState.Paused;

            _timer.Start();
            _timer.Pause();

            Assert.That(_timer.State, Is.EqualTo(expectedState));
        }

        [Test]
        public void Timer_Stop_TimerStateIsStopped()
        {
            var expectedState = TimerState.Stopped;

            _timer.Start();
            _timer.Stop();

            Assert.That(_timer.State, Is.EqualTo(expectedState));
        }

        [Test]
        public void Timer_TimeInMinutes_SetTimeChangedEventFires()
        {
            var expectedEventFired = false;
            _timer.OnSetTimeChanged += () => expectedEventFired = true;

            _timer.TimeInMinutes = 30;

            Assert.That(expectedEventFired, Is.True);
        }


        /// <summary>
        /// No matter the state of the clock, whenever we change the time in TimerSettingsView it should always be set to the new value.
        /// </summary>
        [Test]
        public void Timer_TimeInMinutes_TimeInMinutesNotAffectedByPause()
        {
            _timer.Start();
            _timer.Pause();
            var newTime = 5;
            _timer.TimeInMinutes = newTime;

            _timer.Start();
            _timer.Pause();

            Assert.That(_timer.TimeInMinutes, Is.EqualTo(newTime));
        }

        /// <summary>
        /// No matter the state of the clock, whenever we change the time in TimerSettingsView it should always be set to the new value.
        /// </summary>
        [Test]
        public void Timer_TimeInMinutes_TimeInMinutesNotAffectedByStop()
        {
            _timer.Start();
            _timer.Stop();

            var newTime = 5;
            _timer.TimeInMinutes = newTime;

            _timer.Start();
            _timer.Stop();

            Assert.That(_timer.TimeInMinutes, Is.EqualTo(newTime));
        }

        /// <summary>
        ///  Checks whether Timer.TimeInMinutes is updated properly on setting new time in TimerSettingsViewModel
        /// </summary>
        [Test]
        public void Timer_TimeInMinutes_OnTimerSettingsViewModelUpdate()
        {
            _modalNavigationStoreMock = new Mock<ModalNavigationStore>();
            _pomodoroTimerViewModel = new PomodoroTimerViewModel(_modalNavigationStoreMock.Object);

            _timerSettingsViewModel = new TimerSettingsViewModel(_modalNavigationStoreMock.Object, _pomodoroTimerViewModel);

            var newTime = 5;

            _timerSettingsViewModel.SetTimeString = $"{newTime}";
            _timerSettingsViewModel.Update();

            Assert.That(_pomodoroTimerViewModel.Timer.TimeInMinutes, Is.EqualTo(newTime));
        }
    }
}