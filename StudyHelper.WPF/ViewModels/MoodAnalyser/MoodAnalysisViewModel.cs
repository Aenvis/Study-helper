using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudyHelper.WPF.ViewModels.MoodAnalyser
{
    public enum MoodLevel
    {
        Awful = 0,
        Bad,
        Neutral,
        Good, 
        Great
    }
    public class MoodAnalysisViewModel : ViewModelBase
    {
        public MoodAnalysisViewModel()
        {

        }
        public ISeries[] Series { get; set; } =
    {
        new ColumnSeries<DateTimePoint>
        {
            TooltipLabelFormatter = (chartPoint) =>
                $"{new DateTime((long) chartPoint.SecondaryValue):MMM dd}: {chartPoint.PrimaryValue}",
            Values = new ObservableCollection<DateTimePoint>
            {
                new DateTimePoint(new DateTime(2021, 1, 1), (int)MoodLevel.Bad),
                new DateTimePoint(new DateTime(2021, 1, 3), (int)MoodLevel.Bad),
                new DateTimePoint(new DateTime(2021, 1, 4), (int)MoodLevel.Bad),
                new DateTimePoint(new DateTime(2021, 1, 5), (int)MoodLevel.Bad),
                new DateTimePoint(new DateTime(2021, 1, 6), (int)MoodLevel.Bad),
                new DateTimePoint(new DateTime(2021, 1, 7), (int)MoodLevel.Bad),
                new DateTimePoint(new DateTime(2021, 1, 8), (int)MoodLevel.Bad)
            }
        }
    };

        public Axis[] XAxes { get; set; } =
    {
        new Axis
        {
            Labeler = value => new DateTime((long) value).ToString("MMM dd"),
            LabelsRotation = 30,

            // when using a date time type, let the library know your unit 
            UnitWidth = TimeSpan.FromDays(1).Ticks, 

            // if the difference between our points is in hours then we would:
            //UnitWidth = TimeSpan.FromHours(1).Ticks,

            // since all the months and years have a different number of days
            // we can use the average, it would not cause any visible error in the user interface
            // Months: TimeSpan.FromDays(30.4375).Ticks
            // Years: TimeSpan.FromDays(365.25).Ticks

            // The MinStep property forces the separator to be greater than 1 day.
            MinStep = TimeSpan.FromDays(1).Ticks
        }
    };

        public Axis[] YAxes { get; set; } =
        {
            new Axis
            {
                Labels = Enum.GetNames(typeof(MoodLevel))
                            .ToList()
            }
        };
    }
}
