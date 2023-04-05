using System;

namespace StudyHelper.Domain.Models
{
    public class TodoTask
    {
        public Guid Id { get; }
        public string Title { get; }
        public DateTime? Deadline { get; }

        public TodoTask(Guid id, string title, DateTime? deadline = null)
        {
            Id = id;
            Title = title;
            Deadline = deadline;
        }
    }
}
