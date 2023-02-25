using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<StartTimeCommand>();
                    services.AddTransient<PauseTimeCommand>();
                    services.AddTransient<ResetTimeCommand>();

                    services.AddTransient<OpenTimerSettingsCommand>();
                    services.AddTransient<EditTimerSettingsCommand>();
                    services.AddTransient<CloseModalCommand>();

                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<StudyHelperViewModel>();
                    services.AddSingleton<PomodoroViewModel>();
                    services.AddSingleton<PomodoroTimerViewModel>();

                    services.AddSingleton<ModalNavigationStore>();
                    services.AddSingleton<PomodoroSessionStore>();

                    services.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();

            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            
            base.OnExit(e);
        }
    }
}
