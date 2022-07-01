using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShapeFileLoadingMVVM.App.ViewModels
{
    public class VisibilityControllersListingItemViewModel : BaseViewModel
    {
        private string _layerName;
        public string LayerName 
        {
            get
            { 
                return _layerName;
            }
            set
            {
                _layerName = value;
                OnPropertyChanged(nameof(LayerName));
            }
        }
        public MapLayer MapLayer;

        private bool _isMapLayerVisible;

        public bool IsMapLayerVisibile
        {
            get
            {
                return _isMapLayerVisible;
            }
            set
            {
                _isMapLayerVisible = value;
                if (_isMapLayerVisible)
                    MapLayer.Visibility = Visibility.Visible;
                else
                    MapLayer.Visibility = Visibility.Collapsed;
            }
        }


        public VisibilityControllersListingItemViewModel(MapLayer mapLayer, string layerName)
        {
            LayerName = layerName;
            MapLayer = mapLayer;
            IsMapLayerVisibile = true;
        }
    }
}
