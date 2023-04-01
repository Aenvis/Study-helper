using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.Commands
{
    public class OpenNewTaskCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenNewTaskCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }
        public override void Execute(object? parameter)
        {
            var addNewTaskViewModel = new AddNewTaskViewModel();
            _modalNavigationStore.CurrentViewModel = addNewTaskViewModel;
        }
    }
}
