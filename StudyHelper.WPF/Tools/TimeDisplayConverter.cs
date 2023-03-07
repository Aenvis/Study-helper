using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StudyHelper.WPF.Tools
{
    public class TimeDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int timeInSeconds)
            {
                var minutes = timeInSeconds / 60;
                var seconds = timeInSeconds % 60;

                var minutesStr = minutes < 10 ? $"0{minutes}" : minutes.ToString();
                var secondsStr = seconds < 10 ? $"0{seconds}" : seconds.ToString();

                return minutesStr + " : " + secondsStr;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}