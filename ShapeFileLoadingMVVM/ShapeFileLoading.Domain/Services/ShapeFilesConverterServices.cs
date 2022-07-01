using Catfood.Shapefile;
using Microsoft.Maps.MapControl.WPF;
using ShapeFileLoading.Domain.ExtensionMethods;
using ShapeFileLoading.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoading.Domain.Services
{
    public class ShapeFilesConverterServices : IShapeFilesConverterServices
    {      

        public LocationCollection PointDArrayToLocationCollection(PointD[] points)
        {
            LocationCollection locations = new LocationCollection();

            int numPoints = points.Length;

            for (int i = 0; i < numPoints; i++)
                locations.Add(new Location(points[i].Y, points[i].X));

            return locations;
        }

        public IEnumerable<MapPolygon> ShapeFileToMapPolygon(Shapefile shapeFile)
        {
            foreach (Shape shape in shapeFile)
            {
                if (shape.Type == ShapeType.Polygon)
                {
                    ShapePolygon polygon = shape as ShapePolygon;
                    for (int i = 0; i < polygon.Parts.Count; i++)
                    {
                        if (!polygon.Parts[i].IsCCW())
                        {
                            yield return new MapPolygon()
                            {
                                Locations = PointDArrayToLocationCollection(polygon.Parts[i]),
                                Opacity = 0.7,
                            };
                        }
                    }
                }
            }
        }
    }
}
