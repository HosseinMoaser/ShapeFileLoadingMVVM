using Microsoft.Maps.MapControl.WPF;
using ShapeFileLoading.Domain.Repositories;
using ShapeFileLoading.Domain.Services;
using ShapeFileLoadingMVVM.App.State;
using ShapeFileLoadingMVVM.App.Stores;
using ShapeFileLoadingMVVM.App.ViewModels;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.ObjectModel;
using System.Windows;
using ShapeFileLoadingMVVM.App.HostBuilders;

namespace ShapeFileLoadingMVVM.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().AddShapeFilesServices().AddStores().
                AddViewModels().ConfigureServices((context,services) =>
            {              
                services.AddSingleton<MainWindow>((service) => new MainWindow()
                {
                    DataContext = service.GetRequiredService<MainViewModel>()
                });
            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
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
