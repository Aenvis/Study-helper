using StudyHelper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudyHelper.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {

            StudyHelperViewModel studyHelperViewModel = new StudyHelperViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(studyHelperViewModel)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
