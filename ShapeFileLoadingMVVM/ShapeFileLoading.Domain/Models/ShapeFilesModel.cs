using Catfood.Shapefile;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoadingMVVM.Domain.Models
{
    public class ShapeFilesModel
    {
        public Shapefile ShapeFile;
        public string ShapeFileName;
        public IEnumerable<MapPolygon> MapLayer;
        public ShapeFilesModel(IEnumerable<MapPolygon> mapLayer, string shapeFileName)
        {
            ShapeFileName = shapeFileName;
            MapLayer = mapLayer;
        }
    }
}
