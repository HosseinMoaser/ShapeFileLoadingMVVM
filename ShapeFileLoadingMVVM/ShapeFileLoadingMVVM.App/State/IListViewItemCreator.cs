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
    public interface IListViewItemCreator
    {
        IEnumerable<LayersListingItemViewModel> CreateLayersListViewItems(IEnumerable<ShapeFilesModel> shapeFiles);
    }
}
