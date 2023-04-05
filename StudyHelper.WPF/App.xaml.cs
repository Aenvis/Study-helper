using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudyHelper.Domain.Commands;
using StudyHelper.Domain.Queries;
using StudyHelper.EntityFramework;
using StudyHelper.EntityFramework.Commands;
using StudyHelper.EntityFramework.Queries;
using StudyHelper.WPF.Commands;
using StudyHelper.WPF.Stores;
using StudyHelper.WPF.ViewModels;
using StudyHelper.WPF.ViewModels.TodoList;
using System.Windows;

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
            _host = CreateHost().Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            TodoTasksDbContextFactory todoTasksDbContextFactory = _host.Services.GetRequiredService<TodoTasksDbContextFactory>();

            using (TodoTasksDbContext dbContext = todoTasksDbContextFactory.Create())
            {
                dbContext.Database.Migrate();
            }

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

        private IHostBuilder CreateHost()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<OpenTimerSettingsCommand>();
                    services.AddTransient<ApplyTimerSettingsCommand>();
                    services.AddTransient<CloseModalCommand>();
                    services.AddTransient<IGetTodoTasksQuery, GetTodoTasksQuery>();
                    services.AddTransient<ICreateTodoTaskCommand, CreateTodoTaskCommand>();
                    services.AddTransient<IUpdateTodoTaskCommand, UpdateTodoTaskCommand>();
                    services.AddTransient<IDeleteTodoTaskCommand, DeleteTodoTaskCommand>();
                    string connectionString = "Data Source=todoTasks.db";
                    services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
                    services.AddSingleton<TodoTasksDbContextFactory>();

                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<ApplicationViewModel>();
                    services.AddSingleton<PomodoroViewModel>();
                    services.AddSingleton<PomodoroTimerViewModel>();
                    services.AddSingleton<TodoListViewModel>();

                    services.AddSingleton<ModalNavigationStore>();
                    services.AddSingleton<TodoTasksStore>();

                    services.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainViewModel>()
                    });
                });

                return host;
        }
    }
}
