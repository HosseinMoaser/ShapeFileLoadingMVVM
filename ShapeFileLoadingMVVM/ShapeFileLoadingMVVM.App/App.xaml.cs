using Catfood.Shapefile;
using Microsoft.Maps.MapControl.WPF;
using ShapeFileLoading.Domain.Repositories;
using ShapeFileLoading.Domain.Services;
using ShapeFileLoadingMVVM.App.State;
using ShapeFileLoadingMVVM.App.Stores;
using ShapeFileLoadingMVVM.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShapeFileLoadingMVVM.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private SelectedMapLayerStore _selectedMapLayerStore;
        private readonly IShapeFilesLoadingServices _shapeFilesLoadingServices;
        private readonly ShapeFilesConverterServices _shapeFilesConverterServices;
        private readonly IListViewItemCreator _listViewItemCreator;
        private readonly HomeViewModel _homeViewModel;

        public App()
        {
            _selectedMapLayerStore = new SelectedMapLayerStore();
            _shapeFilesConverterServices = new ShapeFilesConverterServices();
            _shapeFilesLoadingServices = new ShapeFilesLoadingServices(_shapeFilesConverterServices);
            _listViewItemCreator = new ListViewItemCreator();
            var shapeFiles = _shapeFilesLoadingServices.LoadShapeFiles();
            IEnumerable<LayersListingItemViewModel> lisViewItems = _listViewItemCreator.CreateLayersListViewItems(shapeFiles);
            _homeViewModel = new HomeViewModel(_selectedMapLayerStore, lisViewItems, new ObservableCollection<MapLayer>());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_homeViewModel)
            };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
