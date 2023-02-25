using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace StudyHelper.WPF.Models
{
    public class PomodoroTimer
    {
        private readonly DispatcherTimer _timer;

        public PomodoroTimer()
        {

        }

        public void StartTimer() => _timer.Start();
        
    }
}
