using Catfood.Shapefile;
using ShapeFileLoadingMVVM.App.ViewModels;
using ShapeFileLoadingMVVM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoadingMVVM.App.State
{
    public class ListViewItemCreator : IListViewItemCreator
    {
        public IEnumerable<LayersListingItemViewModel> CreateLayersListViewItems(IEnumerable<ShapeFilesModel> shapeFiles)
        {
            foreach(ShapeFilesModel shapefile in shapeFiles)
                yield return new LayersListingItemViewModel(shapefile.MapLayer, shapefile.ShapeFileName);
        }
    }
}
