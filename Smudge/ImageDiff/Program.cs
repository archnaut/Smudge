using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageDiff
{
	class Program
	{
	    public static void Main()
	    {
            ITargetGateway targetGateway = new TargetGatewayStub();
            IProximityHelper proximityHelper = null;
            Point targetCenter = new Point(409, 377);

            Bitmap previousImage = new Bitmap("CleanTarget.PNG");
	    	Bitmap currentImage = targetGateway.GetImage();

            var shot = proximityHelper.GetNearest(targetCenter, previousImage, currentImage);

            var rings = new List<Circle>{
                new Circle(targetCenter, 200),
                new Circle(targetCenter, 400),
                new Circle(targetCenter, 600),
                new Circle(targetCenter, 800),
                new Circle(targetCenter, 1000),
                new Circle(targetCenter, 1200),
                new Circle(targetCenter, 1400),
                new Circle(targetCenter, 1600),
                new Circle(targetCenter, 1800),
                new Circle(targetCenter, 1900),
            };

            
	    }
	}
}