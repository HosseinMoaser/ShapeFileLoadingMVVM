using Catfood.Shapefile;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoading.Domain.Repositories
{
    public interface IShapeFilesConverterServices
    {
        LocationCollection PointDArrayToLocationCollection(PointD[] points);

        IEnumerable<MapPolygon> ShapeFileToMapPolygon(Shapefile shapeFile);

    }
}
