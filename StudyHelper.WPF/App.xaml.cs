using StudyHelper.WPF.Commands;
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
        private readonly PomodoroViewModel pomodoroViewModel;
        private readonly StudyHelperViewModel studyHelperViewModel;
       
        public App()
        {
            PomodoroTimerViewModel pomodoroTimerViewModel = new PomodoroTimerViewModel();
            pomodoroViewModel = new PomodoroViewModel(pomodoroTimerViewModel);
            studyHelperViewModel = new StudyHelperViewModel(pomodoroViewModel);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(studyHelperViewModel)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
