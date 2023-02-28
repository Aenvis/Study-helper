using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Tools
{
    internal static class TimeFormatConverter
    {
        /// <summary>
        /// Helper method that converts given time in seconds to mm : ss format
        /// </summary>
        /// <param name="timeInSeconds"></param>
        /// <returns></returns>
        internal static string SecondsToMmSsString(int timeInSeconds)
        {
            var minutes = (int)timeInSeconds / 60;
            var seconds = (int)timeInSeconds % 60;

            var minutesStr = minutes < 10 ? $"0{minutes}" : minutes.ToString();
            var secondsStr = seconds < 10 ? $"0{seconds}" : seconds.ToString();

            return minutesStr + " : " + secondsStr;
        }
    }
}
