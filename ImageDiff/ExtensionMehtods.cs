using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageDiff
{
    internal static class ExtensionMehtods
    {
        public static double DistanceTo(this Point anchor, Point other)
        {
            return Math.Abs(Math.Pow((other.X - anchor.X), 2) + Math.Pow((other.Y - anchor.Y), 2));
        }

        public static Bitmap Map(this Bitmap image, Func<Color,Color> transform)
        {
            Bitmap result = new Bitmap(image);

            for (var column = 0; column < image.Width; column++)
                for (var row = 0; row < image.Height; row++)
                    result.SetPixel(column, row, transform(image.GetPixel(column, row)));

            return result;
        }
    }
}
