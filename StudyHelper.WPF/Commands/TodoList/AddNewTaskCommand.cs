using StudyHelper.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudyHelper.WPF.Commands
{
    public class AddNewTaskCommand : AsyncCommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddNewTaskCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override Task ExecuteAsync(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
