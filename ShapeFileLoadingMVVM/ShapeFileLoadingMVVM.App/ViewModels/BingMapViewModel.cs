using Microsoft.Maps.MapControl.WPF;
using ShapeFileLoadingMVVM.App.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShapeFileLoadingMVVM.App.ViewModels
{
    public class BingMapViewModel : BaseViewModel
    {
        private readonly SelectedMapLayerStore _selectedMapLayerStore;

        private ObservableCollection<MapLayer> _mapLayersList;
        public ObservableCollection<MapLayer> MapLayersList
        {
            get
            {
                return _mapLayersList;
            }

            set
            {
                _mapLayersList = value;
                OnPropertyChanged(nameof(MapLayersList));
            }
        }

        // Constructor
        public BingMapViewModel(SelectedMapLayerStore selectedMapLayerStore, ObservableCollection<MapLayer> mapLayers)
        {
            MapLayersList = mapLayers;
            MapLayersList.CollectionChanged += MapLayersList_CollectionChanged;
            _selectedMapLayerStore = selectedMapLayerStore;
            _selectedMapLayerStore.SelectedMapLayerChanged += _selectedMapLayerStore_SelectedMapLayerChanged;
        }

        private void MapLayersList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(MapLayersList));
        }

        private void _selectedMapLayerStore_SelectedMapLayerChanged()
        {
            MapLayer mapLayer = new MapLayer();
            foreach (MapPolygon mapPolygon in _selectedMapLayerStore.SelectedMapLayer)
            {
                mapPolygon.Fill = new SolidColorBrush(Color.FromArgb(150, 0, 0, 255));
                mapLayer.Children.Add(mapPolygon);
            }
            MapLayersList.Add(mapLayer);
        }
    }
}
