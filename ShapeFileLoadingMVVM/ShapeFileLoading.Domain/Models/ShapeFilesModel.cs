using Catfood.Shapefile;
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
        public ShapeFilesModel(Shapefile shapeFile, string shapeFileName)
        {
            ShapeFile = shapeFile;
            ShapeFileName = shapeFileName;
        }
    }
}
