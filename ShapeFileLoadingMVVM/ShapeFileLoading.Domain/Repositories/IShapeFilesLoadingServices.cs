using Catfood.Shapefile;
using ShapeFileLoadingMVVM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoading.Domain.Repositories
{
    public interface IShapeFilesLoadingServices
    {
        IEnumerable<ShapeFilesModel> LoadShapeFiles();
    }
}
