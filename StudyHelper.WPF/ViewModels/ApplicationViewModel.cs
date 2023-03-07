using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.ViewModels
{
    public class ApplicationViewModel : ViewModelBase
    {
        public PomodoroViewModel PomodoroViewModel { get; }

        public ApplicationViewModel(PomodoroViewModel pomodoroViewModel)
        {
            PomodoroViewModel = pomodoroViewModel;
        }
    }
}
