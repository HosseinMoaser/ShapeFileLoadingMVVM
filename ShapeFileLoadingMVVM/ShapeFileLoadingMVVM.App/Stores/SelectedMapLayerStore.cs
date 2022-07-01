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
        private IEnumerable<MapPolygon> _selectedMapLayer;

        public IEnumerable<MapPolygon> SelectedMapLayer
        {
            get { return _selectedMapLayer; }
            set
            {
                _selectedMapLayer = value;
                SelectedMapLayerChanged?.Invoke();
            }
        }

        private MapLayer _selectedLayer;
        public MapLayer SelectedLayer
        {
            get
            {
                return _selectedLayer;
            }
            set
            {
                _selectedLayer = value;
                SelectedLayerChanged?.Invoke();
            }
        }

        private string _selectedMapLayerName;
        public string SelectedMapLayerName
        {
            get
            { return _selectedMapLayerName; }
            set
            {
                _selectedMapLayerName = value;
            }
        }

        public event Action SelectedMapLayerChanged;
        public event Action SelectedLayerChanged;
    }
}
