using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace StudyHelper.WPF.Stores
{
    public enum Break
    {
        Short,
        Long
    }

    public class PomodoroSessionStore
    {
        public const int  MaxCycleCount = 3;

        private int _currentCycle;
        public int CurrentCycle => _currentCycle;
        
        public Break CurrentBreak { get; private set; }

        private Dictionary<Break, int> BreakTimes;

        public PomodoroSessionStore()
        {
            BreakTimes = new Dictionary<Break, int>()
            {
            { Break.Short, 5 },
            { Break.Long, 15 }
            };
        }

        public void IncrementCycleCount()
        {
            if(++_currentCycle > MaxCycleCount)
            {
                CurrentBreak = CurrentCycle < 3 ? Break.Short : Break.Long; 
                _currentCycle = 0;
            }
        }

        public int GetBreakTime() => BreakTimes[CurrentBreak];
    }
}
