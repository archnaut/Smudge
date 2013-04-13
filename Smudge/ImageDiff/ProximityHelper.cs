using System;
using System.Drawing;

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
            throw new NotImplementedException();
        }
    }
}
