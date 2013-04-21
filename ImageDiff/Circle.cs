using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageDiff
{
    class Circle
    {
        Point _center;
        int _radius;

        public Circle(Point center, int radius)
        {
            _radius = radius;
            _center = center;
        }

        public int Radius
        {
            get { return _radius; }
        }

        public bool Contains(Point candidate)
        {
            return _center.DistanceTo(candidate) < Math.Pow(_radius,2);
        }
    }
}
