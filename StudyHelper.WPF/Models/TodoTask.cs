using System;

namespace StudyHelper.WPF.Models
{
    public class TodoTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime? Deadline { get; set; }


        public TodoTask(Guid id, string title, DateTime? deadline = null)
        {
            Id = id;
            Title = title;
            Deadline = deadline;
        }
    }
}
