using Catfood.Shapefile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFileLoading.Domain.ExtensionMethods
{
    public static class ShapeFilesReviewers
    {
        public static bool IsCCW(this PointD[] points)
        {
            int count = points.Length;

            // Coordinate 1
            PointD coordinate = points[0];
            int index1 = 0;

            // Coordinate 2
            for (int i = 1; i < count; i++)
            {
                PointD coordinate2 = points[i];
                if (coordinate2.Y > coordinate.Y)
                {
                    coordinate = coordinate2;
                    index1 = i;
                }
            }

            // Coordinate 3
            int num4 = index1 - 1;
            if (num4 < 0)
                num4 = count - 2;
            PointD coordinate3 = points[num4];

            // Coordinate 4
            int num5 = index1 + 1;
            if (num5 >= count)
                num5 = 1;
            PointD coordinate4 = points[num5];

            // Calculate Output
            double num6 = ((coordinate4.X - coordinate.X) * (coordinate3.Y - coordinate.Y)) -
                ((coordinate4.Y - coordinate.Y) * (coordinate3.X - coordinate.X));

            if (num6 == 0.0)
                return (coordinate3.X > coordinate4.X);


            return (num6 > 0.0);
        }
    }
}
