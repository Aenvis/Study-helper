using StudyHelper.WPF.Models;

namespace StudyHelper.WPF.Tests
{
    public class TimerTests
    {
        private Models.Timer _timer;

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
    }
}