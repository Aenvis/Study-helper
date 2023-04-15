using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace StudyHelper.WPF.ViewModels.MoodAnalyser
{
    public class MoodAnalysisViewModel : ViewModelBase
    {
        public ISeries[] Series { get; set; }

        public MoodAnalysisViewModel()
        {
            
        }
    }
}
