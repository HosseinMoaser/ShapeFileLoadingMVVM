using Catfood.Shapefile;
using ShapeFileLoading.Domain.Repositories;
using ShapeFileLoadingMVVM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoading.Domain.Services
{
    public class ShapeFilesLoadingServices : IShapeFilesLoadingServices
    {
        public IEnumerable<ShapeFilesModel> LoadShapeFiles()
        {
            foreach (string file in Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "\\ShapeFiles\\", "*.shp"))         
                yield return new ShapeFilesModel(new Shapefile(file), System.IO.Path.GetFileName(file).Replace(".shp", ""));            
        }
    }
}
