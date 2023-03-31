using System;

namespace StudyHelper.WPF.Models
{
    public class TodoTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly? Deadline { get; set; }


        public TodoTask(Guid id, string title, string description, DateOnly deadline)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline;
        }
    }
}
