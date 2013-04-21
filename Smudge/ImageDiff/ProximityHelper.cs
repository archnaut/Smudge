using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ImageDiff
{
    public interface IProximityHelper
    {
        Point GetNearest(Point reference, Bitmap first, Bitmap second);
    }

    public class ProximityHelper : IProximityHelper
    {
        public Point GetNearest(Point reference, Bitmap first, Bitmap second)
        {
            var diff = ImageTool.GetDifferenceImage(first, second, Color.White);

            return GetPointsOtherThan(diff, Color.White)
                .Select(x => new {Point = x, Distance = reference.DistanceTo(x)})
                .OrderBy(x => x.Distance)
                .Select(x => x.Point)
                .FirstOrDefault();
        }

        private IEnumerable<Point> GetPointsOtherThan(Bitmap bitmap, Color color)
        {
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    if (bitmap.GetPixel(x, y).ToArgb() != color.ToArgb())
                        yield return new Point(x, y);
                }
            }
        }
    }
}
