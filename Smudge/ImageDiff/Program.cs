using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageDiff
{
	class Program
	{
	    public static void Main()
	    {
	    	Bitmap cleanTarget = new Bitmap("CleanTarget.PNG");
	    	Bitmap dirtyTarget = new Bitmap("DirtyTarget.PNG");
	    	
	        Bitmap diff = ImageTool.GetDifferenceImage(cleanTarget, dirtyTarget, Color.Pink);
	        diff.MakeTransparent(Color.Pink);
	        diff.Save("test-diff.png",ImageFormat.Png);

            for(ve
	    }
	}
}