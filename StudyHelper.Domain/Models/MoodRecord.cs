namespace StudyHelper.Domain.Models
{
    public enum MoodLevel
    {
        Awful = 0,
        Bad,
        Neutral,
        Good,
        Great
    }

    public class MoodRecord
    {
        public MoodLevel Mood { get; }
        public DateTime DateTime { get; }

        public MoodRecord(MoodLevel mood, DateTime date)
        {
            Mood = mood;
            DateTime = date;
        }
    }
}
