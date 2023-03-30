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
        public event Action<int>? OnPomodoroTimeUpdated;

        public int SetTime { get; set; }

        public PomodoroSessionStore()
        {
            SetTime = 12;
        }

        public void Update(int time) => OnPomodoroTimeUpdated?.Invoke(time);
    }
}
