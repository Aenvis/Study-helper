using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.ViewModels
{
    public class StudyHelperViewModel : ViewModelBase
    {
        public PomodoroViewModel PomodoroViewModel { get; }

        public StudyHelperViewModel(PomodoroViewModel pomodoroViewModel)
        {
            PomodoroViewModel = pomodoroViewModel;
        }
    }
}
