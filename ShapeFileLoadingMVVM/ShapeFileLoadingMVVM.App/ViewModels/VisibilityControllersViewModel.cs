using ShapeFileLoadingMVVM.App.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoadingMVVM.App.ViewModels
{
    public class VisibilityControllersViewModel : BaseViewModel
    {
        private SelectedMapLayerStore _selectedMapLayerStore;

        public SelectedMapLayerStore SelectedMapLayerStore
        {
            get
            { return _selectedMapLayerStore; }
            set
            {
                _selectedMapLayerStore = value;
            }
        }

        private VisibilityControllersListingItemViewModel _selectedVisibilityControllersListingItemViewModel;
        public VisibilityControllersListingItemViewModel SelectedVisibilityControllersListingItem 
        {
            get { return _selectedVisibilityControllersListingItemViewModel; }
            set 
            {
                _selectedVisibilityControllersListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedVisibilityControllersListingItem));
            }
        }

        private ObservableCollection<VisibilityControllersListingItemViewModel> _visibilityControllersListingItemViewModels;
        public IEnumerable<VisibilityControllersListingItemViewModel> VisibilityControllersListingItemViewModels => _visibilityControllersListingItemViewModels;

        // Constructor
        public VisibilityControllersViewModel(SelectedMapLayerStore selectedMapLayerStore)
        {
            _visibilityControllersListingItemViewModels = new ObservableCollection<VisibilityControllersListingItemViewModel>();
            _visibilityControllersListingItemViewModels.CollectionChanged += _visibilityControllersListingItemViewModels_CollectionChanged;
            _selectedMapLayerStore = selectedMapLayerStore;
            _selectedMapLayerStore.SelectedLayerChanged += _selectedMapLayerStore_SelectedLayerChanged;
        }

        private void _visibilityControllersListingItemViewModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(VisibilityControllersListingItemViewModels));
        }

        private void _selectedMapLayerStore_SelectedLayerChanged()
        {
            _visibilityControllersListingItemViewModels.Add(new VisibilityControllersListingItemViewModel(_selectedMapLayerStore.SelectedLayer,
                _selectedMapLayerStore.SelectedMapLayerName));
        }
    }
}
