using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyHelper.WPF.ViewModels
{
    public class TaskDetailsFormViewModel : ViewModelBase
    {
        private string? _title;
        public string? Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private DateTime? _deadline;
        public DateTime? Deadline
        {
            get => _deadline;
            set
            {
                _deadline = value;
                OnPropertyChanged(nameof(Deadline));
            }
        }

        public ICommand? SubmitCommand { get; }
        public ICommand? CancelCommand { get; }

        public bool CanSubmit => !string.IsNullOrEmpty(Title);

        public TaskDetailsFormViewModel(ICommand? submitCommand, ICommand? cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;

        }

    }
}
