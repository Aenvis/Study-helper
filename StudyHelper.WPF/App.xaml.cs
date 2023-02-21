using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudyHelper.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly PomodoroViewModel _pomodoroViewModel;
        private readonly StudyHelperViewModel _studyHelperViewModel;

        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly PomodoroSessionStore _pomodoroSessionStore;
        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _pomodoroSessionStore = new PomodoroSessionStore();
            PomodoroTimerViewModel pomodoroTimerViewModel = new PomodoroTimerViewModel(_modalNavigationStore, _pomodoroSessionStore);
            _pomodoroViewModel = new PomodoroViewModel(pomodoroTimerViewModel);
            _studyHelperViewModel = new StudyHelperViewModel(_pomodoroViewModel);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_studyHelperViewModel, _modalNavigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
