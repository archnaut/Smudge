using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ImageDiff
{
	class Program
	{
	    public static void Main()
	    {
            
            ITargetGateway targetGateway = new TargetGatewayStub();
            IProximityHelper proximityHelper = new ProximityHelper();
            Point targetCenter = new Point(409, 377);

            Bitmap previousImage = targetGateway.GetImage();
	    	Bitmap currentImage = targetGateway.GetImage();
            
            previousImage.GetPixel(
            
            var shot = proximityHelper.GetNearest(targetCenter, previousImage, currentImage);

            var rings = new List<Circle>{
                new Circle(targetCenter, 36),
                new Circle(targetCenter, 103),
                new Circle(targetCenter, 170),
                new Circle(targetCenter, 234),
                new Circle(targetCenter, 304),
                new Circle(targetCenter, 371)
            };

            var ring = rings.First(x => x.Contains(shot));

            Console.WriteLine(ring.Radius);
            Console.ReadKey();
	    }
	}
}