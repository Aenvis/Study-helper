using StudyHelper.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace StudyHelper.WPF.ViewModels
{
    public class PomodoroViewModel : ViewModelBase
    {
        public PomodoroTimerViewModel PomodoroTimerViewModel { get; }

        public PomodoroViewModel(ModalNavigationStore modalNavigationStore)
        {
            PomodoroTimerViewModel = new PomodoroTimerViewModel(modalNavigationStore);
        }
    }
}
