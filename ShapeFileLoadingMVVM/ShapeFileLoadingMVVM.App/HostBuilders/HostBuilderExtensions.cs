using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Maps.MapControl.WPF;
using ShapeFileLoading.Domain.Repositories;
using ShapeFileLoading.Domain.Services;
using ShapeFileLoadingMVVM.App.State;
using ShapeFileLoadingMVVM.App.Stores;
using ShapeFileLoadingMVVM.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoadingMVVM.App.HostBuilders
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddShapeFilesServices(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IShapeFilesConverterServices, ShapeFilesConverterServices>();
                services.AddSingleton<ShapeFilesConverterServices>();
                services.AddSingleton<IShapeFilesLoadingServices, ShapeFilesLoadingServices>();
                services.AddSingleton<ShapeFilesLoadingServices>();

            });
            return hostBuilder;
        }

        public static IHostBuilder AddStores(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IListViewItemCreator, ListViewItemCreator>();
                services.AddSingleton<ListViewItemCreator>();
                services.AddSingleton<SelectedMapLayerStore>();
                services.AddScoped<ObservableCollection<MapLayer>>();
            });
            return hostBuilder;
        }

        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<HomeViewModel>((service) => new HomeViewModel(service.GetRequiredService<SelectedMapLayerStore>()
                     , service.GetRequiredService<ListViewItemCreator>().CreateLayersListViewItems(service.GetRequiredService<ShapeFilesLoadingServices>().LoadShapeFiles()),
                     service.GetRequiredService<ObservableCollection<MapLayer>>()));
                services.AddSingleton<MainViewModel>();
            });
            return hostBuilder;
        }

    }
}
