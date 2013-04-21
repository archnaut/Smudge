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
        Bitmap GetImage();
    }

    internal class TargetGatewayStub : ITargetGateway
    {
        private Random _random;
        private Bitmap _image;

        public TargetGatewayStub()
        {
            _random = new Random();
            _image = new Bitmap("CleanTarget.PNG");
        }

        public Bitmap GetImage()
        {
            var image = _image.Map(x => x.GetBrightness() < .5 ? Color.Black : Color.White);

            _image = new Bitmap("DirtyTarget.PNG");

            return image;
        }

        private static Bitmap RotateImage(Bitmap image, float angle)
        {
            return RotateImage(image, angle, Color.Transparent);
        }

        private Bitmap Img2BW(Bitmap imgSrc, double threshold)
        {
            int width = imgSrc.Width;
            int height = imgSrc.Height;
            Color pixel;
            Bitmap imgOut = new Bitmap(imgSrc);

            for (int row = 0; row < height - 1; row++)
            {
                for (int col = 0; col < width - 1; col++)
                {
                    pixel = imgSrc.GetPixel(col, row);

                    if (pixel.GetBrightness() < threshold)
                        imgOut.SetPixel(col, row, Color.Black);
                    else
                        imgOut.SetPixel(col, row, Color.White);
                }
            }

            return imgOut;
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
