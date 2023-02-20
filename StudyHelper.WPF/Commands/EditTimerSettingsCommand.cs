using StudyHelper.WPF.Stores;
using System.Windows.Input;

namespace StudyHelper.WPF.Commands
{
    public class EditTimerSettingsCommand : CommandBase
    {
        private ModalNavigationStore _modalNavigationStore;

        public EditTimerSettingsCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            _modalNavigationStore.Close();
        }
    }
}