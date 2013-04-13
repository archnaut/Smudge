using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace ImageDiff
{
    interface ITargetGateway
    {
        public Bitmap GetImage();
    }

    internal class TargetGatewayStub : ITargetGateway
    {
        private Random _random;
        private Bitmap _image;

        public TargetGatewayStub()
        {
            _random = new Random();
            _image = new Bitmap("DirtyTarget.PNG");
        }

        public Bitmap GetImage()
        {
            var angle = _random.Next(360);

            return RotateImage(_image, angle);
        }

        private static Bitmap RotateImage(Bitmap image, float angle)
        {
            return RotateImage(image, angle, Color.Transparent);
        }

        private static Bitmap RotateImage(Bitmap image, float angle, Color bkColor)
        {
            int w = image.Width;
            int h = image.Height;
            PixelFormat pf = default(PixelFormat);
            if (bkColor == Color.Transparent)
            {
                pf = PixelFormat.Format32bppArgb;
            }
            else
            {
                pf = image.PixelFormat;
            }

            Bitmap tempImg = new Bitmap(w, h, pf);
            Graphics g = Graphics.FromImage(tempImg);
            g.Clear(bkColor);
            g.DrawImageUnscaled(image, 1, 1);
            g.Dispose();

            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, w, h));
            Matrix mtrx = new Matrix();
            //Using System.Drawing.Drawing2D.Matrix class 
            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);
            Bitmap newImg = new Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height), pf);
            g = Graphics.FromImage(newImg);
            g.Clear(bkColor);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tempImg, 0, 0);
            g.Dispose();
            tempImg.Dispose();
            return newImg;
        }
    }
}
