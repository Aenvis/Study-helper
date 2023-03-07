using StudyHelper.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyHelper.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        public ViewModelBase? CurrentModalViewModel => _modalNavigationStore?.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;

        public ApplicationViewModel ApplicationViewModel { get; }

        public MainViewModel(ModalNavigationStore modalNavigationStore, ApplicationViewModel applicationViewModel)
        {
            _modalNavigationStore = modalNavigationStore;

            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;
            ApplicationViewModel = applicationViewModel;
        }

        public override void Dispose()
        {
            base.Dispose();
            _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;

        }

        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
