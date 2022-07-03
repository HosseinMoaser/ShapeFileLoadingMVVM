using ShapeFileLoadingMVVM.App.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoadingMVVM.App.ViewModels
{
    public class LayersListingViewModel : BaseViewModel
    {
        private readonly SelectedMapLayerStore _selectedMapLayerStore;
        private  IEnumerable<LayersListingItemViewModel> _mapLayersListingItemViewModels;
        public IEnumerable<LayersListingItemViewModel> MapLayersListingItemViewModels {
            get { return _mapLayersListingItemViewModels; }
            set
            {
                _mapLayersListingItemViewModels = value;
                OnPropertyChanged(nameof(MapLayersListingItemViewModels));
            }
        }

        private LayersListingItemViewModel _selectedLayersListingItemViewModel;

        public LayersListingItemViewModel SelectedLayersListingItemViewModel 
        { 
            get { return _selectedLayersListingItemViewModel; }
            set
            {
                _selectedLayersListingItemViewModel = value;

                if(!_selectedLayersListingItemViewModel.IsSelected)
                {                   
                    _selectedMapLayerStore.SelectedMapLayerName = _selectedLayersListingItemViewModel.ShapeFileName;
                    OnPropertyChanged(nameof(SelectedLayersListingItemViewModel));                  
                    _selectedLayersListingItemViewModel.IsSelected = true;
                    _selectedMapLayerStore.SelectedMapLayer = _selectedLayersListingItemViewModel?.MapLayer;
                }
            } 
        }


        public LayersListingViewModel(SelectedMapLayerStore selectedMapLayerStore, IEnumerable<LayersListingItemViewModel> mapLayersListingItemViewModels)
        {
            _selectedMapLayerStore = selectedMapLayerStore;
            MapLayersListingItemViewModels = mapLayersListingItemViewModels;

        }

        
    }
}
