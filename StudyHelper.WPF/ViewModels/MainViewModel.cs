using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public StudyHelperViewModel StudyHelperViewModel { get; }

        public MainViewModel(StudyHelperViewModel studyHelperViewModel)
        {
            StudyHelperViewModel = studyHelperViewModel;
        }
    }
}
