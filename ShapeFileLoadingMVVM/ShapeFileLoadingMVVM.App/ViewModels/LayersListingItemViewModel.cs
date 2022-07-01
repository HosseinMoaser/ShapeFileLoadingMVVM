using Catfood.Shapefile;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoadingMVVM.App.ViewModels
{
    public class LayersListingItemViewModel : BaseViewModel
    {
        public string ShapeFileName { get; }

        public IEnumerable<MapPolygon> MapLayer { get; }

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

        public LayersListingItemViewModel(IEnumerable<MapPolygon> mapLayer, string shapeFileName)
        {
            MapLayer = mapLayer;
            ShapeFileName = shapeFileName;
        }
    }
}
