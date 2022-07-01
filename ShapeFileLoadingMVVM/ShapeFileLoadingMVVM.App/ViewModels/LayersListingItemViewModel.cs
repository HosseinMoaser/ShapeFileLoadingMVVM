using Catfood.Shapefile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoadingMVVM.App.ViewModels
{
    public class LayersListingItemViewModel : BaseViewModel
    {
        public Shapefile ShapeFile { get; }

        public string ShapeFileName { get; }

        public LayersListingItemViewModel(Shapefile shapeFile, string shapeFileName)
        {
            ShapeFile = shapeFile;
            ShapeFileName = shapeFileName;
        }
    }
}
