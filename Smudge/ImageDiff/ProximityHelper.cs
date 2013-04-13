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
            var diff = ImageTool.GetDifferenceImage(first, second, Color.Pink);

            return GetPointsOtherThan(diff, Color.Pink)
                .Select(x => new {Point = x, Distance = Math.Abs(Math.Sqrt(Math.Pow(reference.X - x.X, 2) + Math.Pow(reference.Y - x.Y, 2)))})
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
