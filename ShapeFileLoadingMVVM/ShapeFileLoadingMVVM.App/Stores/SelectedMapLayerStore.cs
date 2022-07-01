using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoadingMVVM.App.Stores
{
    public class SelectedMapLayerStore
    {
        private MapLayer _selectedMapLayer;

        public MapLayer SelectedMapLayer
        {
            get { return _selectedMapLayer; }
            set
            {
                _selectedMapLayer = value;
                SelectedMapLayerChanged?.Invoke();
            }
        }

        public event Action SelectedMapLayerChanged;
    }
}
