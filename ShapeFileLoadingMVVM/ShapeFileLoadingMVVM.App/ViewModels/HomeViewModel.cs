using Microsoft.Maps.MapControl.WPF;
using ShapeFileLoadingMVVM.App.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoadingMVVM.App.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public BingMapViewModel BingMapViewModel { get; }
        public LayersListingViewModel LayersListingViewModel { get; }
        public VisibilityControllersViewModel VisibilityControllersViewModel { get; }

        public HomeViewModel(SelectedMapLayerStore selectedMapLayerStore, IEnumerable<LayersListingItemViewModel> mapLayersListingItemViewModels
            ,ObservableCollection<MapLayer> mapLayers)
        {
            VisibilityControllersViewModel = new VisibilityControllersViewModel(selectedMapLayerStore);
            BingMapViewModel = new BingMapViewModel(selectedMapLayerStore,mapLayers);
            LayersListingViewModel = new LayersListingViewModel(selectedMapLayerStore, mapLayersListingItemViewModels);           
        }

    }
}
