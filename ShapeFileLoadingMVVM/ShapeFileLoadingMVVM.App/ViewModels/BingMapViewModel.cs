using ShapeFileLoadingMVVM.App.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoadingMVVM.App.ViewModels
{
    public class BingMapViewModel : BaseViewModel
    {
        private readonly SelectedMapLayerStore _selectedMapLayerStore;

        // Constructor
        public BingMapViewModel(SelectedMapLayerStore selectedMapLayerStore)
        {
            _selectedMapLayerStore = selectedMapLayerStore;
            _selectedMapLayerStore.SelectedMapLayerChanged += _selectedMapLayerStore_SelectedMapLayerChanged;
        }

        private void _selectedMapLayerStore_SelectedMapLayerChanged()
        {
            throw new NotImplementedException();
        }
    }
}
