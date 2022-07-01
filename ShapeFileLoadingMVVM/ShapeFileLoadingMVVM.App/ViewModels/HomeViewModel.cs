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

        public HomeViewModel(SelectedMapLayerStore selectedMapLayerStore, IEnumerable<LayersListingItemViewModel> mapLayersListingItemViewModels)
        {
            BingMapViewModel = new BingMapViewModel(selectedMapLayerStore);
            LayersListingViewModel = new LayersListingViewModel(selectedMapLayerStore, mapLayersListingItemViewModels);
            VisibilityControllersViewModel = new VisibilityControllersViewModel();
        }

    }
}
