using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectManagement.Services;
using ProjectManagement.Views;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;

namespace ProjectManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static readonly IHost _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(c =>
            {
                _ = c.SetBasePath(AppContext.BaseDirectory);
            })
            .ConfigureServices(
                (_1, services) =>
                {
                    // App Host
                    _ = services.AddHostedService<ApplicationHostService>();

                    // Main window container with navigation
                    _ = services.AddSingleton<MainWindow>();
                    _ = services.AddSingleton<LoginWindow>();
                    //_ = services.AddSingleton<MainWindowViewModel>();
                    //_ = services.AddSingleton<INavigationService, NavigationService>();
                    //_ = services.AddSingleton<ISnackbarService, SnackbarService>();
                    //_ = services.AddSingleton<IContentDialogService, ContentDialogService>();
                    //_ = services.AddSingleton<WindowsProviderService>();

                    //// Top-level pages
                    //_ = services.AddSingleton<DashboardPage>();
                    //_ = services.AddSingleton<DashboardViewModel>();
                    //_ = services.AddSingleton<AllControlsPage>();
                    //_ = services.AddSingleton<AllControlsViewModel>();
                    //_ = services.AddSingleton<SettingsPage>();
                    //_ = services.AddSingleton<SettingsViewModel>();

                    //// All other pages and view models
                    //_ = services.AddTransientFromNamespace("Wpf.Ui.Gallery.Views", GalleryAssembly.Asssembly);
                    //_ = services.AddTransientFromNamespace(
                    //    "Wpf.Ui.Gallery.ViewModels",
                    //    GalleryAssembly.Asssembly
                    //);
                }
            )
            .Build();

        private void OnStartup(object sender, StartupEventArgs e)
        {
            _host.Start();
        }
    }

}
