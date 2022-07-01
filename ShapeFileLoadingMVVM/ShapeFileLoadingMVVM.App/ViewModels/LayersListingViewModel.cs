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

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        private LayersListingItemViewModel _selectedLayersListingItemViewModel;
        public LayersListingItemViewModel SelectedLayersListingItemViewModel { 
            get { return _selectedLayersListingItemViewModel; }
            set
            {
                _selectedLayersListingItemViewModel = value;

                if(!_selectedLayersListingItemViewModel.IsSelected)
                {
                    OnPropertyChanged(nameof(SelectedLayersListingItemViewModel));
                    _selectedMapLayerStore.SelectedMapLayer = _selectedLayersListingItemViewModel?.MapLayer;
                    _selectedMapLayerStore.SelectedMapLayerName = _selectedLayersListingItemViewModel.ShapeFileName;
                    _selectedLayersListingItemViewModel.IsSelected = true;
                }
            } }


        public LayersListingViewModel(SelectedMapLayerStore selectedMapLayerStore, IEnumerable<LayersListingItemViewModel> mapLayersListingItemViewModels)
        {
            _selectedMapLayerStore = selectedMapLayerStore;
            MapLayersListingItemViewModels = mapLayersListingItemViewModels;
        }

        
    }
}
